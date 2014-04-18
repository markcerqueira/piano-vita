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
		pianoNoteDictionary.Add(TICKS_PER_BEAT, new PianoNote(TICKS_PER_BEAT, 60)); 
		pianoNoteDictionary.Add(TicksForBeat(2), new PianoNote(TicksForBeat(2), 55));
		pianoNoteDictionary.Add(TicksForBeat(3.5), new PianoNote(TicksForBeat(3.5), 60));
		pianoNoteDictionary.Add(TicksForBeat(4), new PianoNote(TicksForBeat(4), 60));
	}
}

