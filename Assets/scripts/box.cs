using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private float xRange = 2f;
    private float yRange = 2f;

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
            float randomX = Random.Range(1.5f - xRange, 1.5f + xRange);
            float randomY = Random.Range(-0.82f - yRange, -0.82f + yRange);
            inventory[index].transform.position = new Vector2(randomX, randomY);
         
            inventory[index].SetActive(true);
        }
        inventory.Clear();
    }
}
