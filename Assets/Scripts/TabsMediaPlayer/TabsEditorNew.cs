using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabsEditorNew : TabsMenu
{
    public InputField fileNameInputfield;

    public override void ShowMenu(bool isShown)
    {
        base.ShowMenu(isShown);

        DisplayError(fileNameInputfield);
    }

    public void ValidateFields()
    {
        string content = fileNameInputfield.text;
        bool isValid = true;
        if (content == string.Empty)
        {
            DisplayError(fileNameInputfield, "Field required");
            isValid = false;
        }
        if (content.Contains(".txt"))
        {
            DisplayError(fileNameInputfield, "Remove the extension");
            isValid = false;
        }


        if (isValid)
        {
            DisplayError(fileNameInputfield);
            TabsEditorManager inst = TabsEditorManager.standalone;
            if (inst == null)
                return;

            inst.CreateNewTabs(content);
        }
    }

    void DisplayError(InputField fields, string errorText = "")
    {
        Text[] texts = fileNameInputfield.GetComponentsInChildren<Text>();
        for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i].tag == "errorField")
            {
                texts[i].text = errorText;
                break;
            }
        }
    }
}
