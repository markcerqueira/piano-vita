using System;
using System.Collections.Generic;

public class SongZelda {
	private readonly static int TICKS_PER_BEAT = 50;
	private readonly static int OCTAVE = 3;
	private readonly static int KEYCHANGE = 0;
	public SongZelda () {
	
	}
	
	public static int TicksForBeat(double beat) {
		return (int)(TICKS_PER_BEAT * beat);
	}
	
	public static int MidiNoteForInterval(int interval) {
		return OCTAVE * 12 + KEYCHANGE + interval;
	}
	
	public static void LoadIntoDictionary(Dictionary<Int32, PianoNote> pianoNoteDictionary) {
		pianoNoteDictionary.Add(TICKS_PER_BEAT, new PianoNote(TICKS_PER_BEAT, MidiNoteForInterval(0))); 
		pianoNoteDictionary.Add(TicksForBeat(2), new PianoNote(TicksForBeat(2), MidiNoteForInterval(-5)));
		pianoNoteDictionary.Add(TicksForBeat(3.5), new PianoNote(TicksForBeat(3.5), MidiNoteForInterval(0)));
		pianoNoteDictionary.Add(TicksForBeat(4), new PianoNote(TicksForBeat(4), MidiNoteForInterval(0)));
		pianoNoteDictionary.Add(TicksForBeat(4.25), new PianoNote(TicksForBeat(4.25), MidiNoteForInterval(2)));
		pianoNoteDictionary.Add(TicksForBeat(4.5), new PianoNote(TicksForBeat(4.5), MidiNoteForInterval(4)));
		pianoNoteDictionary.Add(TicksForBeat(4.75), new PianoNote(TicksForBeat(4.75), MidiNoteForInterval(5)));
		pianoNoteDictionary.Add(TicksForBeat(5), new PianoNote(TicksForBeat(5), MidiNoteForInterval(7)));
		pianoNoteDictionary.Add(TicksForBeat(7.5), new PianoNote(TicksForBeat(7.5), MidiNoteForInterval(7)));
		pianoNoteDictionary.Add(TicksForBeat(8), new PianoNote(TicksForBeat(8), MidiNoteForInterval(7)));
		pianoNoteDictionary.Add(TicksForBeat(8.5), new PianoNote(TicksForBeat(8.5), MidiNoteForInterval(8)));
		pianoNoteDictionary.Add(TicksForBeat(8.75), new PianoNote(TicksForBeat(8.75), MidiNoteForInterval(10)));
		pianoNoteDictionary.Add(TicksForBeat(9), new PianoNote(TicksForBeat(9), MidiNoteForInterval(12)));
		
		pianoNoteDictionary.Add(TicksForBeat(11.5), new PianoNote(TicksForBeat(12.5), MidiNoteForInterval(12)));
		pianoNoteDictionary.Add(TicksForBeat(12), new PianoNote(TicksForBeat(13), MidiNoteForInterval(12)));
		pianoNoteDictionary.Add(TicksForBeat(12.5), new PianoNote(TicksForBeat(13.5), MidiNoteForInterval(10)));
		pianoNoteDictionary.Add(TicksForBeat(13), new PianoNote(TicksForBeat(14), MidiNoteForInterval(8)));
		pianoNoteDictionary.Add(TicksForBeat(13.25), new PianoNote(TicksForBeat(14.25), MidiNoteForInterval(10)));
		pianoNoteDictionary.Add(TicksForBeat(13.5), new PianoNote(TicksForBeat(14.5), MidiNoteForInterval(8)));
		pianoNoteDictionary.Add(TicksForBeat(13.75), new PianoNote(TicksForBeat(14.75), MidiNoteForInterval(7)));
		
		pianoNoteDictionary.Add(TicksForBeat(15), new PianoNote(TicksForBeat(15), MidiNoteForInterval(7)));		
		pianoNoteDictionary.Add(TicksForBeat(15.3), new PianoNote(TicksForBeat(15.3), MidiNoteForInterval(7)));
		pianoNoteDictionary.Add(TicksForBeat(15.6), new PianoNote(TicksForBeat(15.6), MidiNoteForInterval(7)));
		pianoNoteDictionary.Add(TicksForBeat(16), new PianoNote(TicksForBeat(16), MidiNoteForInterval(5)));
		pianoNoteDictionary.Add(TicksForBeat(16.5), new PianoNote(TicksForBeat(16.5), MidiNoteForInterval(5)));
		pianoNoteDictionary.Add(TicksForBeat(17), new PianoNote(TicksForBeat(17), MidiNoteForInterval(7)));
		pianoNoteDictionary.Add(TicksForBeat(17.25), new PianoNote(TicksForBeat(17.25), MidiNoteForInterval(8)));
		
		pianoNoteDictionary.Add(TicksForBeat(18), new PianoNote(TicksForBeat(18), MidiNoteForInterval(7)));
		pianoNoteDictionary.Add(TicksForBeat(18.5), new PianoNote(TicksForBeat(18.5), MidiNoteForInterval(5)));		
		pianoNoteDictionary.Add(TicksForBeat(19), new PianoNote(TicksForBeat(19), MidiNoteForInterval(3)));
		pianoNoteDictionary.Add(TicksForBeat(19.5), new PianoNote(TicksForBeat(19.5), MidiNoteForInterval(3)));
		pianoNoteDictionary.Add(TicksForBeat(19.75), new PianoNote(TicksForBeat(19.75), MidiNoteForInterval(5)));
		pianoNoteDictionary.Add(TicksForBeat(20), new PianoNote(TicksForBeat(20), MidiNoteForInterval(7)));
		
		pianoNoteDictionary.Add(TicksForBeat(21), new PianoNote(TicksForBeat(21), MidiNoteForInterval(5)));
		pianoNoteDictionary.Add(TicksForBeat(21.5), new PianoNote(TicksForBeat(21.5), MidiNoteForInterval(3)));
		pianoNoteDictionary.Add(TicksForBeat(22), new PianoNote(TicksForBeat(22), MidiNoteForInterval(2)));
		pianoNoteDictionary.Add(TicksForBeat(22.5), new PianoNote(TicksForBeat(22.5), MidiNoteForInterval(2)));
		pianoNoteDictionary.Add(TicksForBeat(22.75), new PianoNote(TicksForBeat(22.75), MidiNoteForInterval(4)));
		pianoNoteDictionary.Add(TicksForBeat(23), new PianoNote(TicksForBeat(23), MidiNoteForInterval(6)));
		
		pianoNoteDictionary.Add(TicksForBeat(25), new PianoNote(TicksForBeat(25), MidiNoteForInterval(9)));
		pianoNoteDictionary.Add(TicksForBeat(26), new PianoNote(TicksForBeat(26), MidiNoteForInterval(7)));
		
		pianoNoteDictionary.Add(TicksForBeat(26.5), new PianoNote(TicksForBeat(26.5), MidiNoteForInterval(-5)));
		pianoNoteDictionary.Add(TicksForBeat(26.75), new PianoNote(TicksForBeat(26.75), MidiNoteForInterval(-5)));
		pianoNoteDictionary.Add(TicksForBeat(27), new PianoNote(TicksForBeat(27), MidiNoteForInterval(-5)));
		pianoNoteDictionary.Add(TicksForBeat(27.5), new PianoNote(TicksForBeat(27.5), MidiNoteForInterval(-5)));
		pianoNoteDictionary.Add(TicksForBeat(28), new PianoNote(TicksForBeat(28), MidiNoteForInterval(-5)));
		pianoNoteDictionary.Add(TicksForBeat(28.5), new PianoNote(TicksForBeat(28.5), MidiNoteForInterval(-5)));
		pianoNoteDictionary.Add(TicksForBeat(29), new PianoNote(TicksForBeat(29), MidiNoteForInterval(-5)));
		pianoNoteDictionary.Add(TicksForBeat(29.5), new PianoNote(TicksForBeat(29.5), MidiNoteForInterval(-5)));	
	}
}

