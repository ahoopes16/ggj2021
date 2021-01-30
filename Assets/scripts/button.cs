using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class button : Button
{

    // Update is called once per frame
    void Update()
    {
        Button button = this.GetComponent<Button>();
        Text text = (Text)button.GetComponentInChildren<Text>();

        ColorBlock colors = this.colors;

        if (this.currentSelectionState == SelectionState.Normal) {
            text.color = colors.normalColor;
        } else if (this.currentSelectionState == SelectionState.Highlighted) {
            text.color = colors.highlightedColor;
        } else if (this.currentSelectionState == SelectionState.Pressed) {
            text.color = colors.pressedColor;
        }
    }
}
