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
    public GameObject gameCanvas;
    private string phase = "delivery";
    private List<GameObject> unclaimedItems = new List<GameObject>();
    private ItemMetaData itemMetaData = new ItemMetaData();
    private List<GameObject> people = new List<GameObject>();
    private GameObject activePerson;
    private float timeSincePersonArrived = 0;
    private bool isClueOneDisplayed = false;
    private bool isClueTwoDisplayed = false;
    private bool isClueThreeDisplayed = false;
    private bool gameComplete = false;

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
            items.Remove(item);
            item.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            GameObject createdObject;
            createdObject = Instantiate(item, RandomPosition.GetRandomTablePosition(), Quaternion.identity);
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
            GameObject newPerson = Instantiate(personPrefab, new Vector3(-12, -2, 0), Quaternion.identity);
            people.Add(newPerson);
            Person personBehavior = newPerson.GetComponent<Person>();
            personBehavior.SetLostItem(claimedItem);
            personBehavior.SetLostItemMetaData(itemMetaData.GetMetaDataForItem(claimedItem.name));
        }

        activePerson = people[0];
        activePerson.GetComponent<Person>().EnterScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(phase == "delivery" && !gameComplete) {
            time += Time.deltaTime;
            timeSincePersonArrived += Time.deltaTime;
            if (timeSincePersonArrived > 2 && !isClueOneDisplayed)
            {
                DisplayClueOne();
            }
            if (timeSincePersonArrived > 7 && !isClueTwoDisplayed)
            {
                DisplayClueTwo();
            }
            if (timeSincePersonArrived > 12 && !isClueThreeDisplayed)
            {
                DisplayClueThree();
            }
        }
    }

    public void SetPhase(string phase) {
        // provide "organization" or "delivery" (or other phase handlers?)
        this.phase = phase;
    }

    public string GetPhase() {
        return this.phase;
    }

    public void PutItemInBox(GameObject item, Box boxComponent)
    {
        Debug.Log("GameManager is putting item " + item + " in box " + boxComponent);
        boxComponent.AddObject(item);
        item.SetActive(false);
    }

    public void ValidateItemForPerson(GameObject item)
    {
        Debug.Log("GameManager is validating item " + item + " with person " + activePerson);
        Person activePersonBehavior = activePerson.GetComponent<Person>();
        bool isValid = activePersonBehavior.ValidateItem(item);
        if (isValid)
        {
            HandleValidItem(item);
        } else
        {
            HandleInvalidItem(item);
        }

    }

    void HandleValidItem(GameObject item)
    {
        Person activePersonBehavior = activePerson.GetComponent<Person>();
        activePersonBehavior.ExitScene();

        people.Remove(activePerson);
        gameCanvas.GetComponent<canvasSpeech>().ClearSpeechBubble();
        Destroy(item);

        if (people.Count > 0)
        {
            isClueOneDisplayed = isClueTwoDisplayed = isClueThreeDisplayed = false;
            activePerson = people[0];
            activePerson.GetComponent<Person>().EnterScene();
            timeSincePersonArrived = 0;
        }
        else
        {
            gameComplete = true;
            Debug.Log("CONGRATS YOU'RE DONE!!!!");
        }
    }

    void HandleInvalidItem(GameObject item)
    {
        Debug.Log("NOPE THAT WAS WRONG");
        item.transform.position = RandomPosition.GetRandomTablePosition();
    }

    void DisplayClueOne()
    {
        Debug.Log("GameManager triggering displayClueOne");
        Person personBehavior = activePerson.GetComponent<Person>();
        string clue = personBehavior.GetClueOne();
        gameCanvas.GetComponent<canvasSpeech>().SetClueOne(clue);
        isClueOneDisplayed = true;
    }

    void DisplayClueTwo()
    {
        Debug.Log("GameManager triggering displayClueTwo");
        Person personBehavior = activePerson.GetComponent<Person>();
        string clue = personBehavior.GetClueTwo();
        gameCanvas.GetComponent<canvasSpeech>().SetClueTwo(clue);
        isClueTwoDisplayed = true;
    }
    
    void DisplayClueThree()
    {
        Debug.Log("GameManager triggering displayClueThree");
        Person personBehavior = activePerson.GetComponent<Person>();
        string clue = personBehavior.GetClueThree();
        gameCanvas.GetComponent<canvasSpeech>().SetClueThree(clue);
        isClueThreeDisplayed = true;
    }
}
