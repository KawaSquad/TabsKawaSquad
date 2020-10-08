using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsEditableTile : MonoBehaviour
{
    public int fret = 0;
    Text textTile = null;
    Button thisButton;

    private void Start()
    {
        if (textTile == null)
            textTile = GetComponentInChildren<Text>();

        if (textTile == null)
            Debug.LogError("Text is missing");


        if (fret == 0)
            textTile.text = "";
        else
            textTile.text = fret.ToString();

        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() => ActionClick());
    }

    void ActionClick()
    {
        Debug.Log("ActionClick");
    }
}
