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
    private float xRange = 2f;
    private float yRange = 2f;
    private List<GameObject> unclaimedItems = new List<GameObject>();
    private ItemMetaData itemMetaData = new ItemMetaData();

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
            item.gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

            // Put at random position
            float randomX = Random.Range(1.5f - xRange, 1.5f + xRange);
            float randomY = Random.Range(-0.82f - yRange, -0.82f + yRange);

            // Instantiate
            Debug.Log("Instantiating item " + item.name + " at position (" + randomX + "," + randomY + ")");
            GameObject createdObject = Instantiate(item, new Vector3(randomX, randomY, -2), Quaternion.identity);
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
            GameObject newPerson = Instantiate(personPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Person personBehavior = newPerson.GetComponent<Person>();
            personBehavior.setLostItem(claimedItem);
            personBehavior.setLostItemMetaData(itemMetaData.getMetaDataForItem(claimedItem.name));
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

    public void PutItemInBox(GameObject item, box boxComponent)
    {
        Debug.Log("GameManager is putting item " + item + " in box " + boxComponent);
        boxComponent.addObject(item);
        item.SetActive(false);
    }

    public void ValidateItemForPerson(GameObject item, Person person)
    {
        Debug.Log("GameManager is validating item " + item + " with person " + person);
        person.ValidateItem(item);
    }
}
