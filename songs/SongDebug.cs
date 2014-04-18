using System;
using System.Collections.Generic;

public class SongDebug {
	public SongDebug () {
	
	}
	
	public static void LoadIntoDictionary(Dictionary<Int32, PianoNote> pianoNoteDictionary) {
		pianoNoteDictionary.Add(50, new PianoNote(50, 36));
		pianoNoteDictionary.Add(100, new PianoNote(100, 44));
		pianoNoteDictionary.Add(120, new PianoNote(120, 48));
		pianoNoteDictionary.Add(130, new PianoNote(130, 52));
		pianoNoteDictionary.Add(140, new PianoNote(140, 60));
		pianoNoteDictionary.Add(150, new PianoNote(150, 70));
		pianoNoteDictionary.Add(155, new PianoNote(155, 75));
		pianoNoteDictionary.Add(160, new PianoNote(160, 82));	
	}
}

