using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public List<GameObject> inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addObject(GameObject obj) {
        inventory.Add(obj);
    }

    public void OnMouseUp() {
        for (int index = 0; index < inventory.Count; index++) {
            inventory[index].SetActive(true);
        }
        inventory.Clear();
    }
}
