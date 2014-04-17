using System;
using System.Collections.Generic;

using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Graphics;

using Sample;
using System.IO;

public class SongLoader {
    private static Dictionary<String, Texture2D> textureMap = new Dictionary<String, Texture2D>();
	
	private static Random randomNumberGenerator = new Random((int)DateTime.Now.Ticks);
	
	private static String[] trollImageList = Directory.GetFiles("/Application/images/troll/");
	
	private readonly static float IMAGE_SCALE = 0.4f;

	private static int ticksperbeat = 50;
	
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
	
	public static void LoadZeldaTheme(Dictionary<Int32, PianoNote> pianoNoteDictionary, GraphicsContext graphics, bool trollModeEnabled) {
		
		pianoNoteDictionary.Add(ticksperbeat, new PianoNote(ticksperbeat, 60)); 
		pianoNoteDictionary.Add(ticksForBeat(2), new PianoNote(ticksForBeat(2), 55));
		pianoNoteDictionary.Add(ticksForBeat(3.5), new PianoNote(ticksForBeat(3.5), 60));
		pianoNoteDictionary.Add(ticksForBeat(4), new PianoNote(ticksForBeat(4), 60));
		pianoNoteDictionary.Add(ticksForBeat(4.25), new PianoNote(ticksForBeat(4.25), 62));
		pianoNoteDictionary.Add(ticksForBeat(4.5), new PianoNote(ticksForBeat(4.5), 64));
		pianoNoteDictionary.Add(ticksForBeat(4.75), new PianoNote(ticksForBeat(4.75), 65));
		pianoNoteDictionary.Add(ticksForBeat(5), new PianoNote(ticksForBeat(5), 67));
		pianoNoteDictionary.Add(ticksForBeat(7.5), new PianoNote(ticksForBeat(7.5), 67));
		pianoNoteDictionary.Add(ticksForBeat(8), new PianoNote(ticksForBeat(8), 67));
		pianoNoteDictionary.Add(ticksForBeat(8.5), new PianoNote(ticksForBeat(8.5), 68));
		pianoNoteDictionary.Add(ticksForBeat(8.75), new PianoNote(ticksForBeat(8.75), 70));
		pianoNoteDictionary.Add(ticksForBeat(9), new PianoNote(ticksForBeat(9), 72));
		
		pianoNoteDictionary.Add(ticksForBeat(11.5), new PianoNote(ticksForBeat(12.5), 72));
		pianoNoteDictionary.Add(ticksForBeat(12), new PianoNote(ticksForBeat(13), 72));
		pianoNoteDictionary.Add(ticksForBeat(12.5), new PianoNote(ticksForBeat(13.5), 70));
		pianoNoteDictionary.Add(ticksForBeat(13), new PianoNote(ticksForBeat(14), 68));
		pianoNoteDictionary.Add(ticksForBeat(13.25), new PianoNote(ticksForBeat(14.25), 70));
		pianoNoteDictionary.Add(ticksForBeat(13.5), new PianoNote(ticksForBeat(14.5), 68));
		pianoNoteDictionary.Add(ticksForBeat(13.75), new PianoNote(ticksForBeat(14.75), 67));
		
		pianoNoteDictionary.Add(ticksForBeat(15), new PianoNote(ticksForBeat(15), 67));		
		pianoNoteDictionary.Add(ticksForBeat(15.3), new PianoNote(ticksForBeat(15.3), 67));
		pianoNoteDictionary.Add(ticksForBeat(15.6), new PianoNote(ticksForBeat(15.6), 67));
		pianoNoteDictionary.Add(ticksForBeat(16), new PianoNote(ticksForBeat(16), 65));
		pianoNoteDictionary.Add(ticksForBeat(16.5), new PianoNote(ticksForBeat(16.5), 65));
		pianoNoteDictionary.Add(ticksForBeat(17), new PianoNote(ticksForBeat(17), 67));
		pianoNoteDictionary.Add(ticksForBeat(17.25), new PianoNote(ticksForBeat(17.25), 68));
		
		pianoNoteDictionary.Add(ticksForBeat(18), new PianoNote(ticksForBeat(18), 67));
		pianoNoteDictionary.Add(ticksForBeat(18.5), new PianoNote(ticksForBeat(18.5), 65));		
		pianoNoteDictionary.Add(ticksForBeat(19), new PianoNote(ticksForBeat(19), 63));
		pianoNoteDictionary.Add(ticksForBeat(19.5), new PianoNote(ticksForBeat(19.5), 63));
		pianoNoteDictionary.Add(ticksForBeat(19.75), new PianoNote(ticksForBeat(19.75), 65));
		pianoNoteDictionary.Add(ticksForBeat(20), new PianoNote(ticksForBeat(20), 67));
		
		pianoNoteDictionary.Add(ticksForBeat(21), new PianoNote(ticksForBeat(21), 65));
		pianoNoteDictionary.Add(ticksForBeat(21.5), new PianoNote(ticksForBeat(21.5), 63));
		pianoNoteDictionary.Add(ticksForBeat(22), new PianoNote(ticksForBeat(22), 62));
		pianoNoteDictionary.Add(ticksForBeat(22.5), new PianoNote(ticksForBeat(22.5), 62));
		pianoNoteDictionary.Add(ticksForBeat(22.75), new PianoNote(ticksForBeat(22.75), 64));
		pianoNoteDictionary.Add(ticksForBeat(23), new PianoNote(ticksForBeat(23), 66));
		
		pianoNoteDictionary.Add(ticksForBeat(25), new PianoNote(ticksForBeat(25), 69));
		pianoNoteDictionary.Add(ticksForBeat(26), new PianoNote(ticksForBeat(26), 67));
		
		pianoNoteDictionary.Add(ticksForBeat(26.5), new PianoNote(ticksForBeat(26.5), 55));
		pianoNoteDictionary.Add(ticksForBeat(26.75), new PianoNote(ticksForBeat(26.75), 55));
		pianoNoteDictionary.Add(ticksForBeat(27), new PianoNote(ticksForBeat(27), 55));
		pianoNoteDictionary.Add(ticksForBeat(27.5), new PianoNote(ticksForBeat(27.5), 55));
		pianoNoteDictionary.Add(ticksForBeat(28), new PianoNote(ticksForBeat(28), 55));
		pianoNoteDictionary.Add(ticksForBeat(28.5), new PianoNote(ticksForBeat(28.5), 55));
		pianoNoteDictionary.Add(ticksForBeat(29), new PianoNote(ticksForBeat(29), 55));
		pianoNoteDictionary.Add(ticksForBeat(29.5), new PianoNote(ticksForBeat(29.5), 55));
		
		FinishLoadingSongProcess(pianoNoteDictionary, graphics, trollModeEnabled);
	}
	
	public static void PreloadTextures() {
		textureMap.Clear();
		
		int preloadedTextureCount = 0;
		foreach(String trollImageName in trollImageList) {
			if(textureMap.ContainsKey(trollImageName)) {
				Console.Write("PreloadTextures - texture map already contains texture for image with name: " + trollImageName + "\n");
				continue;
			}
			
			textureMap.Add(trollImageName, LoadTexture(trollImageName));
			preloadedTextureCount++;
		}
		
		textureMap.Add("/Application/images/sun.png", LoadTexture("/Application/images/sun.png"));
		preloadedTextureCount++;
		
		Console.Write("PreloadTextures - preloaded " + preloadedTextureCount + " textures.\n");
	}
	
	public static int ticksForBeat(double beat) {
		return (int)(ticksperbeat * beat);
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
			pianoNote.sprite = new SampleSprite(GetPianoNoteTexture(pianoNote, trollModeEnabled), pianoNote.xPos, pianoNote.yPos, 0f, IMAGE_SCALE);
		}
	}
	
	private static Texture2D GetPianoNoteTexture(PianoNote pianoNote, bool trollModeEnabled) {
		String imageName;
		
		if(trollModeEnabled) {
			imageName = trollImageList[randomNumberGenerator.Next(0, trollImageList.Length)];
		} else {
			imageName = "/Application/images/sun.png";
		}
		
		if(textureMap.ContainsKey(imageName)) {
			return textureMap[imageName];	
		}
		
		Texture2D texture = LoadTexture(imageName);
		
		textureMap[imageName] = texture;
			
		return texture;
	}
	
	private static Texture2D LoadTexture(String imageName) {
		var image = new Image(imageName);
        image.Decode();
			
		Console.Write("LoadTexture - image name = " + imageName + "; height = " + image.Size.Height + "; width = " + image.Size.Width+ "\n");
		
		var texture = new Texture2D(image.Size.Width, image.Size.Height, false, PixelFormat.Rgba);
        texture.SetPixels(0, image.ToBuffer());
			
        image.Dispose();
		
		return texture;
	}
}

