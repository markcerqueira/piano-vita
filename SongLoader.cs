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
	
	public static void LoadDebugSong(Dictionary<Int32, PianoNote> pianoNoteDictionary, GraphicsContext graphics) {
		pianoNoteDictionary.Add(50, new PianoNote(50, 10));
		pianoNoteDictionary.Add(100, new PianoNote(100, 40));
		pianoNoteDictionary.Add(120, new PianoNote(120, 70));
		pianoNoteDictionary.Add(130, new PianoNote(130, 100));
		pianoNoteDictionary.Add(140, new PianoNote(140, 40));
		pianoNoteDictionary.Add(150, new PianoNote(150, 60));
		pianoNoteDictionary.Add(155, new PianoNote(155, 10));
		pianoNoteDictionary.Add(160, new PianoNote(160, 80));
		
		FinishLoadingSongProcess(pianoNoteDictionary, graphics);
	}
	
	private static void FinishLoadingSongProcess(Dictionary<Int32, PianoNote> pianoNoteDictionary, GraphicsContext graphics) {		
		foreach(PianoNote pianoNote in pianoNoteDictionary.Values) {
			// calculate all x position values now
			float graphicsFrameWidth = graphics.GetFrameBuffer().Width;
			pianoNote.xPos = (int)(((float)pianoNote.midiValue / 127.0f) * graphicsFrameWidth);
			
			// create sprites
			pianoNote.sprite = new SampleSprite(GetPianoNoteTexture(pianoNote), pianoNote.xPos, pianoNote.yPos, 0f, 0.2f);
		}
	}
	
	public static Texture2D GetPianoNoteTexture(PianoNote pianoNote) {
		if(textureMap.ContainsKey(pianoNote.imageName)) {
			return textureMap[pianoNote.imageName];	
		}
		
		var image = new Image("/Application/" + pianoNote.imageName);
        image.Decode();
			
		var texture = new Texture2D(image.Size.Width, image.Size.Height, false, PixelFormat.Rgba);
        texture.SetPixels(0, image.ToBuffer());
			
        image.Dispose();
		
		textureMap[pianoNote.imageName] = texture;
			
		return texture;
	}
}
