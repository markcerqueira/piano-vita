using System;
using System.Collections.Generic;

using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Graphics;

using Sample;

public class SongLoader {
    private static Dictionary<String, Texture2D> textureMap = new Dictionary<String, Texture2D>();
	
	public SongLoader () {
			
	}
	
	public static void Term() {
        foreach (Texture2D texture in textureMap.Values) {
            texture.Dispose();
        }		
    }
	
	public static void LoadDebugSong(Dictionary<Int32, PianoNote> pianoNoteDictionary, GraphicsContext graphics, bool trollModeEnabled) {
		pianoNoteDictionary.Add(50, new PianoNote(50, 36));
		pianoNoteDictionary.Add(100, new PianoNote(100, 44));
		pianoNoteDictionary.Add(120, new PianoNote(120, 48));
		pianoNoteDictionary.Add(130, new PianoNote(130, 52));
		pianoNoteDictionary.Add(140, new PianoNote(140, 60));
		pianoNoteDictionary.Add(150, new PianoNote(150, 70));
		pianoNoteDictionary.Add(155, new PianoNote(155, 75));
		pianoNoteDictionary.Add(160, new PianoNote(160, 82));
		
		FinishLoadingSongProcess(pianoNoteDictionary, graphics, trollModeEnabled);
	}
	
	private static void FinishLoadingSongProcess(Dictionary<Int32, PianoNote> pianoNoteDictionary, GraphicsContext graphics, bool trollModeEnabled) {		
		foreach(PianoNote pianoNote in pianoNoteDictionary.Values) {
			// calculate all x position values now
			float graphicsFrameWidth = graphics.GetFrameBuffer().Width;
			pianoNote.xPos = (int)(((float)pianoNote.midiValue / 127.0f) * graphicsFrameWidth);
			
			// create sprites
			RefreshPianoNoteSprites(pianoNoteDictionary, graphics, trollModeEnabled);
		}
	}
	
	public static void RefreshPianoNoteSprites(Dictionary<Int32, PianoNote> pianoNoteDictionary, GraphicsContext graphics, bool trollModeEnabled) {
		foreach(PianoNote pianoNote in pianoNoteDictionary.Values) {
			pianoNote.sprite = new SampleSprite(GetPianoNoteTexture(pianoNote, trollModeEnabled), pianoNote.xPos, pianoNote.yPos, 0f, 0.2f);
		}
	}
	
	private static Texture2D GetPianoNoteTexture(PianoNote pianoNote, bool trollModeEnabled) {
		String imageName;
		
		if(trollModeEnabled) {
			imageName = "images/sun-troll.png";
		} else {
			imageName = "images/sun.png";
		}
		
		if(textureMap.ContainsKey(imageName)) {
			return textureMap[imageName];	
		}
		
		var image = new Image("/Application/" + imageName);
        image.Decode();
			
		var texture = new Texture2D(image.Size.Width, image.Size.Height, false, PixelFormat.Rgba);
        texture.SetPixels(0, image.ToBuffer());
			
        image.Dispose();
		
		textureMap[imageName] = texture;
			
		return texture;
	}
}

