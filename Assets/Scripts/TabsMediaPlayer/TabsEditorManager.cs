using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsEditorManager : MonoBehaviour
{
    public static TabsEditorManager standalone;

    public TabsFile sampleTrackFile;
    TabsFile m_CurrentTrackFile;

    void Awake()
    {
        if(standalone != null)
        {
            Debug.LogError("StandAlone is called twice");
        }
        standalone = this;
    }

    private void OnDestroy()
    {
        standalone = null;
    }


    public void CreateNewTabs(string newFilename)
    {
        TabsMenuManager inst = TabsMenuManager.standalone;
        if (inst == null)
            return;

        inst.OpenMenu("EditorTrack");

        m_CurrentTrackFile = Instantiate(sampleTrackFile);
        m_CurrentTrackFile.Initialize(newFilename);

        SaveCurrentTrack();

        //setup tracks
    }
    public void EditTile()
    {

    }

    public void SaveCurrentTrack()
    {
        if(m_CurrentTrackFile == null)
        {
            Debug.Log("Track empty") ;
            return;
        }

        string content = m_CurrentTrackFile.GetFileStruct();
        content += "\n" + "Sample file = ------3--5-66--5-";

        TabsEncoder.WriteTabsFile(m_CurrentTrackFile.TrackName, content);
    }
}
