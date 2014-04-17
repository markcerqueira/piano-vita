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

public static class ImageSample {
    private static GraphicsContext graphics;
	
    private static List<Texture2D> textureList;
    private static List<SampleSprite> spriteList;
	private static Dictionary<Int32, PianoNote> pianoNoteDictionary;
	private static List<PianoNote> activeNoteList;
	
	private static String[] notesA = Directory.GetFiles("/Application/notes/a/");
	private static String[] notesB = Directory.GetFiles("/Application/notes/b/");
	private static String[] notesC = Directory.GetFiles("/Application/notes/c/");
	private static String[] notesD = Directory.GetFiles("/Application/notes/d/");
	private static String[] notesE = Directory.GetFiles("/Application/notes/e/");
	private static String[] notesF = Directory.GetFiles("/Application/notes/f/");
	private static String[] notesG = Directory.GetFiles("/Application/notes/g/");
	private static String[][] notesarray = new String[][] { notesC, notesD, notesE, notesF, notesG, notesA, notesB };
	
    static bool loop = true;

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
        graphics = new GraphicsContext();
        SampleDraw.Init(graphics);

        textureList = new List<Texture2D>();
        spriteList = new List<SampleSprite>();
		pianoNoteDictionary = new Dictionary<Int32, PianoNote>();
		activeNoteList = new List<PianoNote>();
		
		loadSong();
		
        return true;
    }
	
	public static void loadSong() {
		pianoNoteDictionary.Add(48, new PianoNote(48, 10));
		pianoNoteDictionary.Add(50, new PianoNote(50, 40));
		pianoNoteDictionary.Add(52, new PianoNote(52, 70));
		pianoNoteDictionary.Add(54, new PianoNote(54, 54));
		pianoNoteDictionary.Add(56, new PianoNote(56, 40));
		pianoNoteDictionary.Add(58, new PianoNote(58, 60));
		pianoNoteDictionary.Add(60, new PianoNote(60, 10));
		pianoNoteDictionary.Add(62, new PianoNote(62, 80));
	}

    public static void Term() {
        foreach (var texture in textureList) {
            texture.Dispose();
        }

        foreach (var sprite in spriteList) {
            sprite.Dispose();
        }

        SampleDraw.Term();
        graphics.Dispose();
    }

    public static bool Update() {
        SampleDraw.Update();
		
        return true;
    }
			
	private static int time = 0;
	private static int SPEED = 2;
	private static int BOTTOM_OF_SCREEN = 600;			
	private static int PAUSE_HORIZON = 300;
	
	public static Texture2D getFlare() {
		var image = new Image("/Application/sun.png");
        image.Decode();
			
		var texture = new Texture2D(image.Size.Width, image.Size.Height, false, PixelFormat.Rgba);
        texture.SetPixels(0, image.ToBuffer());
			
        image.Dispose();
			
		return texture;
	}
		
	public static bool Render () {
		graphics.SetViewport (0, 0, graphics.GetFrameBuffer ().Width, graphics.GetFrameBuffer ().Height);
		graphics.SetClearColor (0.0f, 0.0f, 0.0f, 0.0f);
		graphics.Clear ();
		
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
			
			newActivePianoNote.yPos = -100;
			newActivePianoNote.soundPlayer = soundPlayerForNote(newActivePianoNote.midiValue);
			activeNoteList.Add (newActivePianoNote);
			
			pianoNoteDictionary.Remove (time);
		}
		
		int i = 0;
		
		// move each active piano note down the screen
		foreach (PianoNote pianoNote in activeNoteList) {
			if (doAdvanceTime) {	
				pianoNote.yPos += SPEED;
			}
			int xPosNormalized = (int)(((float)pianoNote.midiValue / 127.0f) * graphics.GetFrameBuffer().Width);
									
			SampleDraw.DrawText ("yPos of note " + i + " = " + pianoNote.yPos, 0xff00ff99, 0, 50 + i * 30);
			
			SampleDraw.DrawSprite (new SampleSprite (getFlare (), xPosNormalized, pianoNote.yPos, 0f, 0.2f));
			
			i++;
		}
		
		// remove off-screen notes
		List<PianoNote> notesToRemove = new List<PianoNote> ();
		foreach (PianoNote pianoNote in activeNoteList) {
			if (pianoNote.yPos > BOTTOM_OF_SCREEN) {
				notesToRemove.Add (pianoNote);
			}
		}
		foreach (PianoNote pianoNote in notesToRemove) {
			activeNoteList.Remove (pianoNote);
		}		
		
		// grab touches
		foreach (var touchData in Touch.GetData(0)) {
			Boolean removedNote = false;
			
			if (touchData.Status == TouchStatus.Down) {
				int pointX = (int)((touchData.X + 0.5f) * SampleDraw.Width);
				int pointY = (int)((touchData.Y + 0.5f) * SampleDraw.Height);

				SampleDraw.FillCircle (0xff00ff99, pointX, pointY, 10);
				
				// are there any active notes?
				if (removedNote == false && activeNoteList.Count > 0) {
					// grab the most recent note
					PianoNote pianoNote = activeNoteList [0];
					
					// then remove it
					activeNoteList.Remove (pianoNote);
					
					// play the note!
					((SoundPlayer)pianoNote.soundPlayer).Play();
			
					removedNote = true;
				}
			}
		}
		
		SampleDraw.DrawText ("Magic Piano Vita", 0xff00ff99, 0, 0);
		SampleDraw.DrawText ("time = " + time, 0xff00ff99, 0, graphics.GetFrameBuffer().Height - 50);

		graphics.SwapBuffers ();

		return true;
	}
	
	public static SoundPlayer soundPlayerForNote(int note) {
		int octave = (int) (note / 12.0);
		int interval = (int) (note % 12.0);
		Console.Write("octave: " + octave + " interval: " + interval / 2 + "\n");
		var note_filepath = notesarray[octave][interval / 2];
			
		return (new Sound(note_filepath)).CreatePlayer();
	}
}
