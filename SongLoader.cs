using System;
using System.Collections.Generic;

public class SongLoader {
	public SongLoader () {
			
	}
	
	public static void LoadDebugSong(Dictionary<Int32, PianoNote> pianoNoteDictionary) {
		pianoNoteDictionary.Add(50, new PianoNote(50, 10));
		pianoNoteDictionary.Add(100, new PianoNote(100, 40));
		pianoNoteDictionary.Add(120, new PianoNote(120, 70));
		pianoNoteDictionary.Add(130, new PianoNote(130, 100));
		pianoNoteDictionary.Add(140, new PianoNote(140, 40));
		pianoNoteDictionary.Add(150, new PianoNote(150, 60));
		pianoNoteDictionary.Add(155, new PianoNote(155, 10));
		pianoNoteDictionary.Add(160, new PianoNote(160, 80));
	}
}

