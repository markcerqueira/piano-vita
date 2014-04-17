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

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sample;

public static class ImageSample {
    private static GraphicsContext graphics;
	
    private static List<Texture2D> textureList;
    private static List<SampleSprite> spriteList;
	private static Dictionary<Int32, PianoNote> pianoNoteDictionary;
	private static List<PianoNote> activeNoteList;
	
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
		pianoNoteDictionary.Add(50, new PianoNote(50, 10));
		pianoNoteDictionary.Add(100, new PianoNote(100, 40));
		pianoNoteDictionary.Add(120, new PianoNote(120, 70));
		pianoNoteDictionary.Add(130, new PianoNote(130, 100));
		pianoNoteDictionary.Add(140, new PianoNote(140, 40));
		pianoNoteDictionary.Add(150, new PianoNote(150, 60));
		pianoNoteDictionary.Add(155, new PianoNote(155, 10));
		pianoNoteDictionary.Add(160, new PianoNote(160, 80));
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
		var image = new Image("/Application/sun.jpg");
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
			
			activeNoteList.Add (newActivePianoNote);
			
			pianoNoteDictionary.Remove (time);
		}
		
		int i = 0;
		
		// move each active piano note down the screen
		foreach (PianoNote pianoNote in activeNoteList) {
			if (doAdvanceTime) {	
				pianoNote.yPos += SPEED;
			}
			int xPosNormalized = (int)(((float)pianoNote.midiValue / 127.0f) * graphics.GetFrameBuffer ().Width);
						
			SampleDraw.DrawSprite (new SampleSprite (getFlare (), xPosNormalized, pianoNote.yPos, 0f, 0.2f));
			
			SampleDraw.DrawText ("yPos of note " + i + " = " + pianoNote.yPos, 0xff00ff99, 0, 50 + i * 30);
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
					
					// TODO - play the audio!
					
					removedNote = true;
				}
			}
		}
		
		SampleDraw.DrawText ("time = " + time, 0xff00ff99, 0, 0);

		graphics.SwapBuffers ();

		return true;
	}
}
