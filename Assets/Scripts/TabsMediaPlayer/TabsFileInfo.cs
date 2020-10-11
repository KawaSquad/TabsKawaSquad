using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//File struct Json
// 1 - TrackName
// 2 - Author
// 3 - BPM
// 4 - NoteCount


[System.Serializable]
public class TabsFileInfo
{
    public string trackName = "Title";
    public string trackAuthor = "Nova";
    public int bpm = 80;
    public int noteCount = 144;
}
