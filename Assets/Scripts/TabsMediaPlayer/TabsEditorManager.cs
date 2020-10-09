using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsEditorManager : MonoBehaviour
{
    public static TabsEditorManager standalone;

    string m_CurrentTrackFile;

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

        m_CurrentTrackFile = TabsEncoder.GetFilePath(newFilename);


        //setup tracks
    }
    public void EditTile()
    {

    }

    public void SaveCurrentTrack()
    {
        TabsEncoder.WriteTabsFile(m_CurrentTrackFile, "NewFile");
    }
}
