using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private GameObject lostItem;
    private ItemData lostItemMetaData;
    private bool enterFlag = false;
    private bool exitFlag = false;

    public void Update()
    {
        if (enterFlag)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(-4.5f, transform.position.y), 3f * Time.deltaTime);

        }

        if (exitFlag)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(-12, transform.position.y), 2f * Time.deltaTime);
        }
    }

    public void SetLostItem(GameObject item)
    {
        lostItem = item;
    }

    public void SetLostItemMetaData(ItemData itemMetaData)
    {
        lostItemMetaData = itemMetaData;
    }

    public bool ValidateItem(GameObject item)
    {
        Debug.Log("Validating item " + item);

        return item == lostItem;
    }
    public string GetClueOne()
    {
        return $"I'm looking for {lostItemMetaData.typeHint}.";
    }

    public string GetClueTwo()
    {
        Item lostItemColor = lostItem.GetComponent<Item>();
        return $"I think it was {lostItemColor.GetColorName()}.";
    }

    public string GetClueThree()
    {
        return $"Oh yeah! I lost my {lostItemMetaData.displayName}.";
    }

    public void EnterScene()
    {
        Debug.Log("Person enter scene called!");
        enterFlag = true;
        exitFlag = false;
    }

    public void ExitScene()
    {
        enterFlag = false;
        exitFlag = true;
    }
}
