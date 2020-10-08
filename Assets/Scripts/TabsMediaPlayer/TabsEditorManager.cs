using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsEditorManager : MonoBehaviour
{
    public static TabsEditorManager standalone;

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


    public void CreateNewTabs()
    {
        TabsMenuManager inst = TabsMenuManager.standalone;
        if (inst == null)
            return;


        inst.OpenMenu("EditorTrack");

        //setup tracks
    }
    public void EditTile()
    {

    }
}
