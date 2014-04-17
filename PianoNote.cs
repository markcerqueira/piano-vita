using System;
using Sce.PlayStation.Core.Audio;

public class PianoNote {
	private int time;
	
	public int midiValue;
	public int yPos;
	
	public SoundPlayer soundPlayer;
	
	public PianoNote (int time, int midiValue) {
		this.time = time;
		this.midiValue = midiValue;
	}
}

