using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemColor : MonoBehaviour
{
    private string colorName = "none";
    static readonly Dictionary<string, Color> colors = new Dictionary<string, Color>
    {
        { "white", new Color32(255,255,255,255) },
        { "blue", new Color32(31,58,166,255) },
        { "red", new Color32(166,31,35,255) },
        { "green", new Color32(31,166,35,255) },
        { "purple", new Color32(104,49,159,255) },
        { "yellow", new Color32(191,169,37,255) },
        { "orange", new Color32(188,88,35,255) },
        { "light blue", new Color32(33,198,221,255) },
        { "grey", new Color32(150,150,150,255) },
        { "pink", new Color32(162,76,153,255) },
    };

    // Start is called before the first frame update
    void Start()
    {
        // Get a random color from color dict
        List<string> possibleColors = new List<string>(colors.Keys);
        int randomColorIndex = Random.Range(0, possibleColors.Count - 1);
        Color randomColor;
        this.colorName = possibleColors[randomColorIndex];
        colors.TryGetValue(this.colorName, out randomColor);

        // Set Sprite Color
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = randomColor;
    }

    public string GetColorName()
    {
        return colorName;
    }
}