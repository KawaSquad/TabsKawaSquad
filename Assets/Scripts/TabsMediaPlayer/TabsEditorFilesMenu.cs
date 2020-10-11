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

        if (isShown)
            RefreshFiles();
    }

    public void RefreshFiles()
    {
        TabsFile[] oldFiles = filesContainer.GetComponentsInChildren<TabsFile>();
        for (int i = 0; i < oldFiles.Length; i++)
        {
            Destroy(oldFiles[i].gameObject);
        }


        string[] files = TabsEncoder.GetTabsFiles();
        for (int i = 0; i < files.Length; i++)
        {
            string filePath = files[i];
            TabsFileInfo trackInfo = TabsEncoder.ReadTabsPreview(filePath);

            if (trackInfo != null)
            {
                TabsFile newFile = Instantiate(sampleFile, filesContainer);
                newFile.Initialize(trackInfo);
            }
        }
    }

}
