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
	
	public SongLoader () {
			
	}
	
	public static void Term() {
        foreach (Texture2D texture in textureMap.Values) {
            texture.Dispose();
        }		
    }
	
	public static void LoadDebugSong(Dictionary<Int32, PianoNote> pianoNoteDictionary, GraphicsContext graphics, bool trollModeEnabled) {
		SongDebug.LoadIntoDictionary(pianoNoteDictionary);
		
		FinishLoadingSongProcess(pianoNoteDictionary, graphics, trollModeEnabled);
	}
	
	public static void LoadZeldaSong(Dictionary<Int32, PianoNote> pianoNoteDictionary, GraphicsContext graphics, bool trollModeEnabled) {
		SongZelda.LoadIntoDictionary(pianoNoteDictionary);
		
		FinishLoadingSongProcess(pianoNoteDictionary, graphics, trollModeEnabled);
	}
	
	public static void LoadFiddleSong(Dictionary<Int32, PianoNote> pianoNoteDictionary, GraphicsContext graphics, bool trollModeEnabled) {
		SongFiddle.LoadIntoDictionary(pianoNoteDictionary);
		
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

