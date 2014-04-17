using System;

using Sample;

public class PianoNote {
	public int time;
	public int midiValue;
	public int xPos;
	public int yPos;
	
	public SampleSprite sprite;
	public String imageName;

	public PianoNote (int time, int midiValue) {
		this.time = time;
		this.midiValue = midiValue;
		this.imageName = "sun.png";
	}
	
	public PianoNote (int time, int midiValue, String imageName) {
		this.time = time;
		this.midiValue = midiValue;
		this.imageName = imageName;
	}
}

