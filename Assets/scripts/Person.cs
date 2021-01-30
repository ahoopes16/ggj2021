using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private GameObject lostItem;
    private ItemData lostItemMetaData;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setLostItem(GameObject item)
    {
        lostItem = item;
    }

    public void setLostItemMetaData(ItemData itemMetaData)
    {
        lostItemMetaData = itemMetaData;
    }
}
