using System;
using System.Collections.Generic;

public class SongZelda {
	private readonly static int TICKS_PER_BEAT = 50;
	
	public SongZelda () {
	
	}
	
	public static int TicksForBeat(double beat) {
		return (int)(TICKS_PER_BEAT * beat);
	}
	
	public static void LoadIntoDictionary(Dictionary<Int32, PianoNote> pianoNoteDictionary) {
		pianoNoteDictionary.Add(TICKS_PER_BEAT, new PianoNote(TICKS_PER_BEAT, 60)); 
		pianoNoteDictionary.Add(TicksForBeat(2), new PianoNote(TicksForBeat(2), 55));
		pianoNoteDictionary.Add(TicksForBeat(3.5), new PianoNote(TicksForBeat(3.5), 60));
		pianoNoteDictionary.Add(TicksForBeat(4), new PianoNote(TicksForBeat(4), 60));
		pianoNoteDictionary.Add(TicksForBeat(4.25), new PianoNote(TicksForBeat(4.25), 62));
		pianoNoteDictionary.Add(TicksForBeat(4.5), new PianoNote(TicksForBeat(4.5), 64));
		pianoNoteDictionary.Add(TicksForBeat(4.75), new PianoNote(TicksForBeat(4.75), 65));
		pianoNoteDictionary.Add(TicksForBeat(5), new PianoNote(TicksForBeat(5), 67));
		pianoNoteDictionary.Add(TicksForBeat(7.5), new PianoNote(TicksForBeat(7.5), 67));
		pianoNoteDictionary.Add(TicksForBeat(8), new PianoNote(TicksForBeat(8), 67));
		pianoNoteDictionary.Add(TicksForBeat(8.5), new PianoNote(TicksForBeat(8.5), 68));
		pianoNoteDictionary.Add(TicksForBeat(8.75), new PianoNote(TicksForBeat(8.75), 70));
		pianoNoteDictionary.Add(TicksForBeat(9), new PianoNote(TicksForBeat(9), 72));
		
		pianoNoteDictionary.Add(TicksForBeat(11.5), new PianoNote(TicksForBeat(12.5), 72));
		pianoNoteDictionary.Add(TicksForBeat(12), new PianoNote(TicksForBeat(13), 72));
		pianoNoteDictionary.Add(TicksForBeat(12.5), new PianoNote(TicksForBeat(13.5), 70));
		pianoNoteDictionary.Add(TicksForBeat(13), new PianoNote(TicksForBeat(14), 68));
		pianoNoteDictionary.Add(TicksForBeat(13.25), new PianoNote(TicksForBeat(14.25), 70));
		pianoNoteDictionary.Add(TicksForBeat(13.5), new PianoNote(TicksForBeat(14.5), 68));
		pianoNoteDictionary.Add(TicksForBeat(13.75), new PianoNote(TicksForBeat(14.75), 67));
		
		pianoNoteDictionary.Add(TicksForBeat(15), new PianoNote(TicksForBeat(15), 67));		
		pianoNoteDictionary.Add(TicksForBeat(15.3), new PianoNote(TicksForBeat(15.3), 67));
		pianoNoteDictionary.Add(TicksForBeat(15.6), new PianoNote(TicksForBeat(15.6), 67));
		pianoNoteDictionary.Add(TicksForBeat(16), new PianoNote(TicksForBeat(16), 65));
		pianoNoteDictionary.Add(TicksForBeat(16.5), new PianoNote(TicksForBeat(16.5), 65));
		pianoNoteDictionary.Add(TicksForBeat(17), new PianoNote(TicksForBeat(17), 67));
		pianoNoteDictionary.Add(TicksForBeat(17.25), new PianoNote(TicksForBeat(17.25), 68));
		
		pianoNoteDictionary.Add(TicksForBeat(18), new PianoNote(TicksForBeat(18), 67));
		pianoNoteDictionary.Add(TicksForBeat(18.5), new PianoNote(TicksForBeat(18.5), 65));		
		pianoNoteDictionary.Add(TicksForBeat(19), new PianoNote(TicksForBeat(19), 63));
		pianoNoteDictionary.Add(TicksForBeat(19.5), new PianoNote(TicksForBeat(19.5), 63));
		pianoNoteDictionary.Add(TicksForBeat(19.75), new PianoNote(TicksForBeat(19.75), 65));
		pianoNoteDictionary.Add(TicksForBeat(20), new PianoNote(TicksForBeat(20), 67));
		
		pianoNoteDictionary.Add(TicksForBeat(21), new PianoNote(TicksForBeat(21), 65));
		pianoNoteDictionary.Add(TicksForBeat(21.5), new PianoNote(TicksForBeat(21.5), 63));
		pianoNoteDictionary.Add(TicksForBeat(22), new PianoNote(TicksForBeat(22), 62));
		pianoNoteDictionary.Add(TicksForBeat(22.5), new PianoNote(TicksForBeat(22.5), 62));
		pianoNoteDictionary.Add(TicksForBeat(22.75), new PianoNote(TicksForBeat(22.75), 64));
		pianoNoteDictionary.Add(TicksForBeat(23), new PianoNote(TicksForBeat(23), 66));
		
		pianoNoteDictionary.Add(TicksForBeat(25), new PianoNote(TicksForBeat(25), 69));
		pianoNoteDictionary.Add(TicksForBeat(26), new PianoNote(TicksForBeat(26), 67));
		
		pianoNoteDictionary.Add(TicksForBeat(26.5), new PianoNote(TicksForBeat(26.5), 55));
		pianoNoteDictionary.Add(TicksForBeat(26.75), new PianoNote(TicksForBeat(26.75), 55));
		pianoNoteDictionary.Add(TicksForBeat(27), new PianoNote(TicksForBeat(27), 55));
		pianoNoteDictionary.Add(TicksForBeat(27.5), new PianoNote(TicksForBeat(27.5), 55));
		pianoNoteDictionary.Add(TicksForBeat(28), new PianoNote(TicksForBeat(28), 55));
		pianoNoteDictionary.Add(TicksForBeat(28.5), new PianoNote(TicksForBeat(28.5), 55));
		pianoNoteDictionary.Add(TicksForBeat(29), new PianoNote(TicksForBeat(29), 55));
		pianoNoteDictionary.Add(TicksForBeat(29.5), new PianoNote(TicksForBeat(29.5), 55));	
	}
}

