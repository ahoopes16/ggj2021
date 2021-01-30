using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemData
{
    public string displayName;
    public string typeHint;

    public ItemData(string displayName, string typeHint) : this()
    {
        this.displayName = displayName;
        this.typeHint = typeHint;
    }
}

public class ItemMetaData
{
    private Dictionary<string, ItemData> gameObjectItemDataDict = new Dictionary<string, ItemData>
    {
        { "backpack", new ItemData("backpack", "something you wear") },
        { "baseballCap", new ItemData("baseball cap", "") },
        { "basketball", new ItemData("basketball", "") },
        { "beachBall", new ItemData("beach ball", "") },
        { "beanie", new ItemData("beanie", "") },
        { "bobbypin", new ItemData("bobby pin", "") },
        { "book", new ItemData("book", "") },
        { "boot", new ItemData("boot", "") },
        { "brush", new ItemData("brush", "") },
        { "button", new ItemData("button", "") },
        { "carKey", new ItemData("car key", "") },
        { "cd", new ItemData("CD", "") },
        { "clipboard", new ItemData("clipboard", "") },
        { "coin", new ItemData("coin", "") },
        { "compass", new ItemData("compass", "") },
        { "d20", new ItemData("twenty-sided die", "") },
        { "die", new ItemData("six sided die", "") },
        { "dress", new ItemData("dress", "") },
        { "earRings", new ItemData("earrings", "") },
        { "flashDrive", new ItemData("flash drive", "") },
        { "flipFlop", new ItemData("flip flops", "") },
        { "gameboy", new ItemData("handheld game", "") },
        { "inhaler", new ItemData("inhaler", "") },
        { "key", new ItemData("key", "") },
        { "lightbulb", new ItemData("lightbulb", "") },
        { "lipstick", new ItemData("lipstick", "") },
        { "mask", new ItemData("mask", "") },
        { "mittens", new ItemData("mittens", "") },
        { "mug", new ItemData("mug", "") },
        { "paintbrush", new ItemData("paint brush", "") },
        { "paperAirplane", new ItemData("paper airplane", "") },
        { "paperclip", new ItemData("paperclip", "") },
        { "pencil", new ItemData("pencil", "") },
        { "phone", new ItemData("phone", "") },
        { "pipe", new ItemData("pipe", "") },
        { "playDoo", new ItemData("Play Doo", "") },
        { "raincoat", new ItemData("raincoat", "") },
        { "rosary", new ItemData("rosary", "") },
        { "rubberDuck", new ItemData("rubber duck", "") },
        { "rubeQube", new ItemData("puzzle cube", "") },
        { "ruler", new ItemData("ruler", "") },
        { "sherpie", new ItemData("Sherpie marker", "") },
        { "shirt", new ItemData("shirt", "") },
        { "sock", new ItemData("sock", "") },
        { "sunglasses", new ItemData("sunglasses", "") },
        { "umbrella", new ItemData("umbrella", "") },
        { "watch", new ItemData("watch", "") },
        { "waterBottle", new ItemData("water bottle", "") },
        { "whistle", new ItemData("whistle", "") }
    };

    public ItemData getMetaDataForItem(string itemName)
    {
        ItemData value;
        gameObjectItemDataDict.TryGetValue(itemName, out value);
        return value;
    }
}
