using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TabsFile : MonoBehaviour
{
    //public string filePath;

    [SerializeField]
    TabsFileInfo trackInfo;

    Button thisButton;

    public Text textIndex;
    public Text textTrackName;
    public Text textTrackAuthor;
    public Text textBPM;
    public Text textNoteCount;

    //Getter  <->  Setter 
    public string TrackName
    {
        get
        {
            if (trackInfo != null)
                return trackInfo.trackName;
            return "";
        }
        set
        {
            if (trackInfo == null)
                trackInfo = new TabsFileInfo();
            trackInfo.trackName = value;
        }
    }
    public string TrackAuthor
    {
        get
        {
            if (trackInfo != null)
                return trackInfo.trackAuthor;
            return "";
        }
        set
        {
            if (trackInfo == null)
                trackInfo = new TabsFileInfo();
            trackInfo.trackAuthor = value;
        }
    }
    public int BPM
    {
        get
        {
            if (trackInfo != null)
                return trackInfo.bpm;
            return 0;
        }
        set
        {
            if (trackInfo == null)
                trackInfo = new TabsFileInfo();
            trackInfo.bpm = value;
        }
    }
    public int NoteCount
    {
        get
        {
            if (trackInfo != null)
                return trackInfo.noteCount;
            return 0;
        }
        set
        {
            if (trackInfo == null)
                trackInfo = new TabsFileInfo();
            trackInfo.noteCount = value;
        }
    }







    public void Initialize(TabsFileInfo trackInfo)
    {
        this.trackInfo = trackInfo;

        thisButton = this.GetComponent<Button>();
        thisButton.onClick.AddListener(() => OnTrackSelected());


        if (textIndex!= null)
            textIndex.text = "0";

        if (textTrackName != null)
            textTrackName.text = TrackName;

        if (textTrackAuthor != null)
            textTrackAuthor.text = TrackAuthor;

        if (textBPM != null)
            textBPM.text = BPM.ToString();

        if (textNoteCount != null)
            textNoteCount.text = NoteCount.ToString();
    }

    public void Initialize(string fileName) //temp
    {
        trackInfo = new TabsFileInfo();
        trackInfo.trackName = fileName;

        Initialize(trackInfo);
    }


    public void OnTrackSelected()
    {
        TabsEditorManager inst = TabsEditorManager.standalone;
        if (inst == null)
            return;

        inst.CreateNewTabs(TrackName);
    }

    public string GetFileStruct()
    {
        string structFile = JsonUtility.ToJson(trackInfo);

        return structFile;
    }
}
