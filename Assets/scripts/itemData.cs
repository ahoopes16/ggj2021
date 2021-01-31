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
        { "baseballCap", new ItemData("baseball cap", "something you wear") },
        { "basketball", new ItemData("basketball", "something you throw") },
        { "beachBall", new ItemData("beach ball", "something you throw") },
        { "beanie", new ItemData("beanie", "something you wear") },
        { "bobbypin", new ItemData("bobby pin", "something for your hair") },
        { "book", new ItemData("book", "something you read") },
        { "boot", new ItemData("boot", "something you wear") },
        { "brush", new ItemData("brush", "something for your hair") },
        { "button", new ItemData("button", "something small and round") },
        { "carKey", new ItemData("car key", "something used for security") },
        { "cd", new ItemData("CD", "a media device") },
        { "clipboard", new ItemData("clipboard", "something you read") },
        { "coin", new ItemData("coin", "something small and round") },
        { "compass", new ItemData("compass", "something you read") },
        { "d20", new ItemData("twenty-sided die", "something small and round") },
        { "d6", new ItemData("six sided die", "something small and round") },
        { "dress", new ItemData("dress", "something you wear") },
        { "earRings", new ItemData("earrings", "a head accessory") },
        { "flashDrive", new ItemData("flash drive", "a media device") },
        { "flipFlop", new ItemData("flip flops", "something you wear") },
        { "gameboy", new ItemData("a handheld game", "an electronic") },
        { "inhaler", new ItemData("inhaler", "something you put in your mouth") },
        { "key", new ItemData("key", "something used for security") },
        { "lightbulb", new ItemData("lightbulb", "an electronic") },
        { "lipstick", new ItemData("lipstick", "a head accessory") },
        { "mask", new ItemData("mask", "something to protect you when outdoors") },
        { "mittens", new ItemData("mittens", "something you wear") },
        { "mug", new ItemData("mug", "something you drink from") },
        { "paintbrush", new ItemData("paint brush", "something used in art class") },
        { "paperAirplane", new ItemData("paper airplane", "something you throw") },
        { "pencil", new ItemData("pencil", "something used in art class") },
        { "phone", new ItemData("phone", "an electronic") },
        { "pipe", new ItemData("pipe", "something you put in your mouth") },
        { "playDoo", new ItemData("Play Doo", "a toy") },
        { "raincoat", new ItemData("raincoat", "something to protect you when outdoors") },
        { "rubberDuck", new ItemData("rubber duck", "a toy") },
        { "rubeQube", new ItemData("puzzle cube", "a toy") },
        { "ruler", new ItemData("ruler", "something you read") },
        { "sherpie", new ItemData("Sherpie marker", "something used in art class") },
        { "shirt", new ItemData("shirt", "something you wear") },
        { "sock", new ItemData("sock", "something you wear") },
        { "sunglasses", new ItemData("sunglasses", "something to protect you when outdoors") },
        { "umbrella", new ItemData("umbrella", "something to protect you when outdoors") },
        { "watch", new ItemData("watch", "something you read") },
        { "waterBottle", new ItemData("water bottle", "something you drink from") },
        { "whistle", new ItemData("whistle", "something you put in your mouth") }
    };

    public ItemData GetMetaDataForItem(string itemName)
    {
        Debug.Log($"Getting ItemData for {itemName}");
        ItemData value;
        gameObjectItemDataDict.TryGetValue(itemName.Replace("(Clone)",""), out value);
        return value;
    }
}
