using System;
using System.Collections.Generic;

public class SongFiddle {
	private readonly static int TICKS_PER_BEAT = 50;
	
	public SongFiddle () {
	
	}
	
	public static int TicksForBeat(double beat) {
		return (int)(TICKS_PER_BEAT * beat);
	}
	
	public static void LoadIntoDictionary(Dictionary<Int32, PianoNote> pianoNoteDictionary) {
		pianoNoteDictionary.Add(TicksForBeat(1), new PianoNote(TicksForBeat(1), 53)); 
		pianoNoteDictionary.Add(TicksForBeat(1.5), new PianoNote(TicksForBeat(2), 57));
		pianoNoteDictionary.Add(TicksForBeat(2), new PianoNote(TicksForBeat(3.5), 62));
		pianoNoteDictionary.Add(TicksForBeat(2.5), new PianoNote(TicksForBeat(4), 60));
		pianoNoteDictionary.Add(TicksForBeat(3.5), new PianoNote(TicksForBeat(3.5), 55));
		pianoNoteDictionary.Add(TicksForBeat(4), new PianoNote(TicksForBeat(4), 57));
	}
}

