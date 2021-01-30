using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private GameObject lostItem;
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
        Debug.Log(lostItem);
    }
}
