using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
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

    public void AddObject(GameObject obj) {
        inventory.Add(obj);
    }

    public void OnMouseUp() {
        for (int index = 0; index < inventory.Count; index++) {
            inventory[index].transform.position = RandomPosition.GetRandomTablePosition();
            inventory[index].SetActive(true);
        }
        inventory.Clear();
    }
}
