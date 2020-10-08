using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class TabsMenu : MonoBehaviour
{
    CanvasGroup PanelFader;
    public string MenuTag = "Menu";

    public virtual void ShowMenu(bool isShown)
    {
        if (PanelFader == null)
            PanelFader = this.GetComponent<CanvasGroup>();

        PanelFader.alpha = isShown ? 1 : 0;
        PanelFader.blocksRaycasts = isShown;
        PanelFader.interactable = isShown;
    }

    public void ResetMenu()
    {
        if (PanelFader == null)
            PanelFader = this.GetComponent<CanvasGroup>();

        RectTransform rectT = (RectTransform)PanelFader.transform;
        rectT.localPosition = Vector3.zero;
    }
}
