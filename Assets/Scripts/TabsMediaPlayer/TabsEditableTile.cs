using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsEditableTile : MonoBehaviour
{
    public int fret = 0;
    Button thisButton;

    private void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() => ActionClick());
    }

    void ActionClick()
    {
        Debug.Log("ActionClick");
    }
}
