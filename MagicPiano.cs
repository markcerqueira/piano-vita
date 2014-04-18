/* PlayStation(R)Mobile SDK 1.21.02
 * Copyright (C) 2014 Sony Computer Entertainment Inc.
 * All Rights Reserved.
 */
using System;
using System.Collections.Generic;
using System.Threading;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Audio;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using System.IO;
using Sample;

public static class MagicPiano {
    private static GraphicsContext graphics = new GraphicsContext();
	
	private static Dictionary<Int32, PianoNote> pianoNoteDictionary = new Dictionary<Int32, PianoNote>();
	
	private static List<PianoNote> activeNoteList = new List<PianoNote>();
	
	private static SampleButton trollButton;
	private static SampleButton restartButton;
	private static SampleButton songSelectButton;
	
	private static int graphicsFrameWidth;
	private static int graphicsFrameHeight;
	
	private static bool trollModeEnabled = true;
	
	private static bool isRestarting = false;
	
	private static bool loop = true;
	
	private static readonly String DEBUG_SONG_ID = "debug";
	private static readonly String ZELDA_SONG_ID = "zelda";
	private static readonly String FIDDLE_SONG_ID = "fiddle";

	private static int playingSongIndex = 0;
	private static String[] songsArray = new String[] {ZELDA_SONG_ID, FIDDLE_SONG_ID, DEBUG_SONG_ID};
	
	private static String[][] notesarray = new String[][] { 
		Directory.GetFiles("/Application/notes/c/"),
		Directory.GetFiles("/Application/notes/csharp/"),
		Directory.GetFiles("/Application/notes/d/"),
		Directory.GetFiles("/Application/notes/dsharp/"),
		Directory.GetFiles("/Application/notes/e/"),
		Directory.GetFiles("/Application/notes/f/"),
		Directory.GetFiles("/Application/notes/fsharp/"),
		Directory.GetFiles("/Application/notes/g/"),
		Directory.GetFiles("/Application/notes/gsharp/"),
		Directory.GetFiles("/Application/notes/a/"),
		Directory.GetFiles("/Application/notes/asharp/"),
		Directory.GetFiles("/Application/notes/b/")};
	
	private static String[][] trollnotesarray = new String[][] { 
		Directory.GetFiles("/Application/trollnotes/c/"),
		Directory.GetFiles("/Application/trollnotes/csharp/"),
		Directory.GetFiles("/Application/trollnotes/d/"),
		Directory.GetFiles("/Application/trollnotes/dsharp/"),
		Directory.GetFiles("/Application/trollnotes/e/"),
		Directory.GetFiles("/Application/trollnotes/f/"),
		Directory.GetFiles("/Application/trollnotes/fsharp/"),
		Directory.GetFiles("/Application/trollnotes/g/"),
		Directory.GetFiles("/Application/trollnotes/gsharp/"),
		Directory.GetFiles("/Application/trollnotes/a/"),
		Directory.GetFiles("/Application/trollnotes/asharp/"),
		Directory.GetFiles("/Application/trollnotes/b/")};
	
    public static void Main(string[] args) {
        Init();

        while (loop) {
            SystemEvents.CheckEvents();
            Update();
            Render();
        }

        Term();
    }

    public static bool Init() {
        SampleDraw.Init(graphics);
		
		SongLoader.PreloadTextures();

		LoadSong();
		
		LoadLineTexture();
				
		graphicsFrameWidth = graphics.GetFrameBuffer().Width;
		graphicsFrameHeight = graphics.GetFrameBuffer().Height;
		
		int buttonHeight = 48;
		int buttonWidth = 200;
		
		int SONG_SELECT_BUTTON_POS = 2;
		int TROLL_BUTTON_POS = 1;
		int RESTART_BUTTON_POS = 3;
		
		trollButton = new SampleButton(graphicsFrameWidth - buttonWidth * TROLL_BUTTON_POS - (TROLL_BUTTON_POS * 10), graphicsFrameHeight - buttonHeight - 10, buttonWidth, buttonHeight); 
		RefreshTrollButtonText();
		
		songSelectButton = new SampleButton(graphicsFrameWidth - buttonWidth * SONG_SELECT_BUTTON_POS - (SONG_SELECT_BUTTON_POS * 10), graphicsFrameHeight - buttonHeight - 10, buttonWidth, buttonHeight); 
		songSelectButton.SetText(songsArray[0]);

		restartButton = new SampleButton(graphicsFrameWidth - buttonWidth * RESTART_BUTTON_POS - (RESTART_BUTTON_POS * 10), graphicsFrameHeight - buttonHeight - 10, buttonWidth, buttonHeight);
		restartButton.SetText("restart");

        return true;
    }
	
	private static void RefreshTrollButtonText() {
		if(trollModeEnabled) {
			trollButton.SetText("disable troll");
		} else {
			trollButton.SetText("enable troll");
		}	
	}
	
	private static void LoadSong() {
		pianoNoteDictionary.Clear();
		activeNoteList.Clear();
		
		String songId = songsArray[playingSongIndex];
		
		if(songId.Equals(ZELDA_SONG_ID)) {
			SongLoader.LoadZeldaSong(pianoNoteDictionary, graphics, trollModeEnabled);
		} else if (songId.Equals(FIDDLE_SONG_ID)) {
			SongLoader.LoadFiddleSong(pianoNoteDictionary, graphics, trollModeEnabled);
		} else {
			SongLoader.LoadDebugSong(pianoNoteDictionary, graphics, trollModeEnabled);	
		}
	}
	
	private static void RefreshPianoNoteSprites() {
		SongLoader.RefreshPianoNoteSprites(pianoNoteDictionary, graphics, trollModeEnabled);	
		
		foreach (PianoNote note in activeNoteList) {
			note.soundPlayer = soundPlayerForNote(note.midiValue);
		}
	}
	
    public static void Term() {
        SampleDraw.Term();
		
		SongLoader.Term();
		
        graphics.Dispose();
    }

    public static bool Update() {
        SampleDraw.Update();
		
        return true;
    }
	
	private static SampleSprite lineSprite;
	private static void LoadLineTexture() {
		var image = new Image("/Application/line.png");
        image.Decode();
					
		var texture = new Texture2D(image.Size.Width, image.Size.Height, false, PixelFormat.Rgba);
        texture.SetPixels(0, image.ToBuffer());
			
        image.Dispose();
		
		lineSprite = new SampleSprite(texture, 0, PAUSE_HORIZON + 100, 0f, 1.0f);
	}
			
	private static int time = 0;
	private static int SPEED = 2;
	private static int PAUSE_HORIZON = 300;
		
	public static bool Render () {
		graphics.SetViewport (0, 0, graphics.GetFrameBuffer ().Width, graphics.GetFrameBuffer ().Height);
		graphics.SetClearColor (0.0f, 0.0f, 0.0f, 0.0f);
		graphics.Clear ();
		
		SampleDraw.DrawSprite(lineSprite);
		
		// if we're "restarting" stop here
		if(isRestarting) {
			return true;	
		}
		
		// we will stop advancing time if there is a note waiting at the "pause horizon"
		Boolean doAdvanceTime = true;
		
		// if a note has reached the near-bottom area of the screen, stop advancing notes
		if (activeNoteList.Count > 0) {
			PianoNote pianoNote = activeNoteList [0];
			
			if (pianoNote.yPos >= PAUSE_HORIZON) {
				doAdvanceTime = false;
			}
		}
		
		// if the user needs to play a note, we will not advance time
		if (doAdvanceTime) {
			time++;
		}
		
		// pull a note out into the active list if it's the proper time
		if (pianoNoteDictionary.ContainsKey (time)) {
			PianoNote newActivePianoNote = pianoNoteDictionary [time];
			
			newActivePianoNote.soundPlayer = soundPlayerForNote(newActivePianoNote.midiValue);
			activeNoteList.Add (newActivePianoNote);			
		}
		
		int i = 0;
		
		// move each active piano note down the screen
		foreach (PianoNote pianoNote in activeNoteList) {
			if (doAdvanceTime) {	
				pianoNote.yPos += SPEED;
			}
					
			pianoNote.sprite.PositionY = pianoNote.yPos;
			
			// SampleDraw.DrawText ("yPos of note " + i + " = " + pianoNote.yPos, 0xff00ff99, 0, 50 + i * 30);
			SampleDraw.DrawSprite(pianoNote.sprite);
			
			i++;
		}
				
		RemoveOffScreenNotes();	
		
		HandleTouchEvent();
			
		restartButton.Draw();
		trollButton.Draw();
		songSelectButton.Draw();
		
		SampleDraw.DrawText ("Magic Piano Vita", 0xff00ff99, 0, 0);
		SampleDraw.DrawText ("time = " + time, 0xff00ff99, 0, graphics.GetFrameBuffer().Height - 20);

		graphics.SwapBuffers ();

		return true;
	}
	
	public static void RestartSong() {
		isRestarting = true;
		
		LoadSong();
		
		time = 0;
		isRestarting = false;
	}
	
	private static void ToggleSong() {
		playingSongIndex++;
		
		if(playingSongIndex >= songsArray.Length) {
			playingSongIndex = 0;
		}
		
		songSelectButton.SetText(songsArray[playingSongIndex]);
		
		RestartSong();
	}
	
	public static void HandleTouchEvent() {
		List<TouchData> touchDataList = Touch.GetData(0);
		
		// if restart button is touched
		if (restartButton.TouchDown(touchDataList)) {
        	RestartSong();
			
			return;
        }
		
		// if troll button is touched
		if (trollButton.TouchDown(touchDataList)) {
			if(trollModeEnabled) {
				trollModeEnabled = false;
			} else {
				trollModeEnabled = true;
			}
			
			RefreshTrollButtonText();
			
			// refreshes button sprites so images update
			RefreshPianoNoteSprites();
			
			return;
		}
		
		// if song select button is touched
		if (songSelectButton.TouchDown(touchDataList)) {
        	ToggleSong();
						
			return;
        }
		
		foreach (var touchData in touchDataList) {
			// this boolean ensures we don't get multiple notes played per call to Render()
			Boolean removedNote = false;
			
			if (touchData.Status == TouchStatus.Down) {
				int pointX = (int)((touchData.X + 0.5f) * SampleDraw.Width);
				int pointY = (int)((touchData.Y + 0.5f) * SampleDraw.Height);

				SampleDraw.FillCircle (0xff00ff99, pointX, pointY, 4);
				
				// are there any active notes?
				if (removedNote == false && activeNoteList.Count > 0) {
					// grab the most recent note
					PianoNote pianoNote = activeNoteList[0];
					
					float deltaXPercentage = (float)(pointX - pianoNote.xPos)/(graphics.GetFrameBuffer().Width);
					
					Console.Write("Delta from touch to pianoNote render x position: " + deltaXPercentage + "\n");
					
					// then remove it from active note list
					activeNoteList.Remove (pianoNote);
					
					// play the note!
					((SoundPlayer)pianoNote.soundPlayer).Play();
			
					removedNote = true;
				}
			}
		}
	}
	
	public static void RemoveOffScreenNotes() {
		int BOTTOM_OF_SCREEN = 600;			
		
		List<PianoNote> notesToRemove = new List<PianoNote> ();
		foreach (PianoNote pianoNote in activeNoteList) {
			if (pianoNote.yPos > BOTTOM_OF_SCREEN) {
				notesToRemove.Add (pianoNote);
			}
		}
		
		foreach (PianoNote pianoNote in notesToRemove) {
			activeNoteList.Remove (pianoNote);
		}		
	}
	
	public static SoundPlayer soundPlayerForNote(int note) {
		int octave = (int) (note / 12.0);
		int interval = (int) (note % 12.0);
		Console.Write("octave: " + octave + " interval: " + interval / 2 + "\n");
		
		var note_filepath = "";
		
		if (trollModeEnabled) {
			note_filepath = trollnotesarray[interval][octave - 2];
		} else {
			note_filepath = notesarray[interval][octave - 2];
		}
			
		return (new Sound(note_filepath)).CreatePlayer();
	}
}
