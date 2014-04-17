using System;

using Sce.PlayStation.Core.Audio;

using Sample;

public class PianoNote {
	public int time;
	public int midiValue;
	public int xPos;
	public int yPos;
	
	public SampleSprite sprite;
	public String imageName;

	public SoundPlayer soundPlayer;
	
	public PianoNote (int time, int midiValue) {
		this.time = time;
		this.midiValue = midiValue;
		this.imageName = "images/sun.png";
	}
	
	public PianoNote (int time, int midiValue, String imageName) {
		this.time = time;
		this.midiValue = midiValue;
		this.imageName = imageName;
	}
}

