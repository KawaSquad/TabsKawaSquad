using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabsEditorFilesMenu : TabsMenu
{
    public TabsFile sampleFile;

    public Transform filesContainer;

    public override void ShowMenu(bool isShown)
    {
        base.ShowMenu(isShown);

        if(isShown)
        RefreshFiles();
    }

    public void RefreshFiles()
    {
        TabsFile[] oldFiles = filesContainer.GetComponentsInChildren<TabsFile>();
        for (int i = 0; i < oldFiles.Length; i++)
        {
            Destroy(oldFiles[i]);
        }


        string[] files = TabsEncoder.GetTabsFiles();
        for (int i = 0; i < files.Length; i++)
        {
            string filePath = files[i];

            TabsFile newFile = Instantiate(sampleFile);

            newFile.transform.parent = filesContainer;
        }
    }

}
