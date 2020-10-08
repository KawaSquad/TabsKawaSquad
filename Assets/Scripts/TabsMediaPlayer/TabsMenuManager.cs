using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsMenuManager : MonoBehaviour
{
    public static TabsMenuManager standalone;

    void Awake()
    {
        if (standalone != null)
        {
            Debug.LogError("StandAlone is called twice");
        }
        standalone = this;
    }
    private void OnDestroy()
    {
        standalone = null;
    }



    public List<TabsMenu> MenuPanels;

    private void Start()
    {
        ResetAllMenuPanel();
        OpenMenu("MainMenu");
    }

    void ShowMenuPanel(CanvasGroup panel, bool isShown)
    {
        panel.alpha = isShown ? 1 : 0;
        panel.blocksRaycasts = isShown;
        panel.interactable = isShown;
    }
    void ResetMenuPanel(CanvasGroup panel)
    {
        RectTransform rectT = (RectTransform)panel.transform;
        rectT.localPosition = Vector3.zero;//(Screen.width / 2f, Screen.height / 2f, 0f);
    }


    public void ResetAllMenuPanel()
    {
        for (int i = 0; i < MenuPanels.Count; i++)
        {
            MenuPanels[i].ResetMenu();
        }
    }

    public void OpenMenu(string MenuTag)
    {
        bool isMatching = false;
        for (int i = 0; i < MenuPanels.Count; i++)
        {
            if (MenuPanels[i].MenuTag == MenuTag)
            {
                MenuPanels[i].ShowMenu(true);
                isMatching = true;
            }
            else
            {
                MenuPanels[i].ShowMenu(false);
            }
        }

        if (!isMatching)
            Debug.LogError("No : " + MenuTag + " found");
    }
}
