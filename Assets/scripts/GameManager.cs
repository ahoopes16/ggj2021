using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float time = 0.0f;
    public List<GameObject> items;
    public GameObject personPrefab;
    public int numItemsToUse;
    public int numPeople;
    private string phase = "organization";
    private float xRange = 3f;
    private float yRange = 3f;
    private List<GameObject> unclaimedItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        if (numItemsToUse < 1)
        {
            numItemsToUse = 20;
        }


        for (int i = 0; i < numItemsToUse; i++)
        {
            // Get random item
            GameObject item = items[Random.Range(0, items.Count)];

            // Put at random position
            float randomX = Random.Range(0 - xRange, 0 + xRange);
            float randomY = Random.Range(0 - yRange, 0 + yRange);

            // Instantiate
            Debug.Log("Instantiating item " + item.name + " at position (" + randomX + "," + randomY + ")");
            GameObject createdObject = Instantiate(item, new Vector3(randomX, randomY, 0), Quaternion.identity);
            unclaimedItems.Add(createdObject);
        }

        // Generate People
        if(numPeople < 1)
        {
            numPeople = 10;
        }

        for(int i = 0; i < numPeople; i++)
        {
            int randomPosition = Random.Range(0, unclaimedItems.Count);
            GameObject claimedItem = unclaimedItems[randomPosition];
            unclaimedItems.RemoveAt(randomPosition);
            GameObject newPerson = Instantiate(personPrefab, new Vector3(-12, 0, 0), Quaternion.identity);
            Person personBehavior = newPerson.GetComponent<Person>();
            personBehavior.setLostItem(claimedItem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(phase == "delivery") {
            time += Time.deltaTime;
        }
    }

    public void setPhase(string phase) {
        // provide "organization" or "delivery" (or other phase handlers?)
        this.phase = phase;
    }

    public string getPhase() {
        return this.phase;
    }

    public GameObject getRandomGameObject()
    {
        int randomPosition = Random.Range(0, this.unclaimedItems.Count - 1);
        return unclaimedItems[randomPosition];
    }
}
