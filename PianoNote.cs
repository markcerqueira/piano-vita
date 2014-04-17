using System;


public class PianoNote {
	private int time;
	
	public int midiValue;
	public int yPos;
	
	public PianoNote (int time, int midiValue) {
		this.time = time;
		this.midiValue = midiValue;
	}
}

