using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private GameObject lostItem;
    private ItemData lostItemMetaData;

    public void setLostItem(GameObject item)
    {
        lostItem = item;
    }

    public void setLostItemMetaData(ItemData itemMetaData)
    {
        lostItemMetaData = itemMetaData;
    }

    public void ValidateItem(GameObject item)
    {
        Debug.Log("Validating item " + item);

        if (item == lostItem)
        {
            Debug.Log("HOLY COW THAT'S THE ITEM");
        }
        else
        {
            Debug.Log("Nope, you suck");
        }
    }
    public string getClueOne()
    {
        return $"I'm looking for {lostItemMetaData.typeHint}.";
    }

    public string getClueTwo()
    {
        itemColor lostItemColor = lostItem.GetComponent<itemColor>();
        return $"I think it was {lostItemColor.GetColorName()}.";
    }

    public string getClueThree()
    {
        return $"Oh yeah! I lost my {lostItemMetaData.displayName}.";
    }
}
