using System;

using Sce.PlayStation.Core.Audio;

using Sample;

public class PianoNote {
	public int time;
	public int midiValue;
	public int xPos;
	public int yPos;
	
	public SampleSprite sprite;

	public SoundPlayer soundPlayer;
	
	public PianoNote (int time, int midiValue) {
		this.time = time;
		this.midiValue = midiValue;
	}

}

