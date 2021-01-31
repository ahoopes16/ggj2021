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
    public AudioClip organizationBell;
    public AudioClip deliveryBell;
    public AudioClip organizationBGM;
    public AudioClip deliveryBGM;
    public AudioClip cassetteNoises;
    private string lastAudio = "";
    private string phase = "organization";
    private List<GameObject> unclaimedItems = new List<GameObject>();
    private ItemMetaData itemMetaData = new ItemMetaData();
    private List<GameObject> people = new List<GameObject>();
    private GameObject activePerson;
    private float timeSincePersonArrived = 0;
    private bool isClueOneDisplayed = false;
    private bool isClueTwoDisplayed = false;
    private bool isClueThreeDisplayed = false;
    private bool gameComplete = false;
    private AudioSource audiosource;
    private float timeSinceCheckOrX = 0;
    private bool startingMessageShown = false;
    private bool clearXAndCheckCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
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
        audiosource.PlayOneShot(organizationBell, 0.3f);
        lastAudio = "orgbell";
    }

    // Update is called once per frame
    void Update()
    {
        if(!audiosource.isPlaying) {
            switch(lastAudio) {
                case "orgbell":
                    audiosource.PlayOneShot(cassetteNoises, 0.1f);
                    lastAudio = "preorg";
                    break;
                case "preorg":
                    audiosource.loop = true;
                    audiosource.clip = organizationBGM;
                    audiosource.volume = 0.03f;
                    audiosource.Play();
                    lastAudio = "org";
                    break;
                case "deliverybell":
                    audiosource.PlayOneShot(cassetteNoises, 0.1f);
                    lastAudio = "predelivery";
                    break;
                case "predelivery":
                    audiosource.loop = true;
                    audiosource.clip = deliveryBGM;
                    audiosource.volume = 0.03f;
                    audiosource.Play();
                    lastAudio = "delivery";
                    break;
                default:
                    break;
            }
        }
        if(phase == "delivery" && !gameComplete) {
            time += Time.deltaTime;
            timeSincePersonArrived += Time.deltaTime;
            timeSinceCheckOrX += Time.deltaTime;
            if (timeSinceCheckOrX > 2 && !clearXAndCheckCalled)
            {
                ClearXAndCheck();
                clearXAndCheckCalled = true;
            }
            if (timeSincePersonArrived > 2 && !isClueOneDisplayed)
            {
                DisplayClueOne();
            }
            if (timeSincePersonArrived > 17 && !isClueTwoDisplayed)
            {
                DisplayClueTwo();
            }
            if (timeSincePersonArrived > 32 && !isClueThreeDisplayed)
            {
                DisplayClueThree();
            }
        }
        if(phase == "organization")
        {
            DisplayStartingMessage();
            //check all "unclaimed" items are in a box (active = false)
            if(unclaimedItems.Find(item => item.activeSelf == true) == null)
            {
                gameCanvas.GetComponent<canvasSpeech>().ClearSpeechBubble();
                SetPhase("delivery");
                GeneratePeople();
            }
        }
    }

    private void GeneratePeople()
    {
        // Generate People
        if (numPeople < 1)
        {
            numPeople = 10;
        }

        for (int i = 0; i < numPeople; i++)
        {
            int randomPosition = Random.Range(0, unclaimedItems.Count);
            GameObject claimedItem = unclaimedItems[randomPosition];
            unclaimedItems.RemoveAt(randomPosition);
            GameObject newPerson = Instantiate(personPrefab, new Vector3(-12, -2, -2), Quaternion.identity);
            people.Add(newPerson);
            Person personBehavior = newPerson.GetComponent<Person>();
            personBehavior.SetLostItem(claimedItem);
            personBehavior.SetLostItemMetaData(itemMetaData.GetMetaDataForItem(claimedItem.name));
        }

        activePerson = people[0];
        activePerson.GetComponent<Person>().EnterScene();
    }

    public void SetPhase(string phase) {
        // provide "organization" or "delivery" (or other phase handlers?)
        this.phase = phase;
        if(phase == "delivery") {
            audiosource.Stop();
            audiosource.volume = 1;
            audiosource.PlayOneShot(deliveryBell, 0.3f);
            lastAudio = "deliverybell";
        }
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
        ShowCheckOrX(true, false);
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
            GameObject.FindGameObjectWithTag("kidsaudio").GetComponent<KidsYelling>().MakeKidsYell();
            gameCanvas.GetComponent<canvasFinalScore>().ShowFinalScore();
        }
    }

    void HandleInvalidItem(GameObject item)
    {
        Debug.Log("NOPE THAT WAS WRONG");
        item.transform.position = RandomPosition.GetRandomTablePosition();
        ShowCheckOrX(false, true);
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

    void DisplayStartingMessage()
    {
        if (!startingMessageShown)
        {
            Debug.Log("GameManager triggering DisplayStartingMessage");
            gameCanvas.GetComponent<canvasSpeech>().ShowStartMessage();
            startingMessageShown = true;
        }
        
    }

    void ClearXAndCheck()
    {
        Debug.Log("Hiding Check and X");
        gameCanvas.GetComponent<canvasSpeech>().showRedX(false);
        gameCanvas.GetComponent<canvasSpeech>().showGreenCheck(false);
    }
    
    void ShowCheckOrX(bool showCheck, bool showX)
    {
        if (showCheck)
        {
            Debug.Log("Showing Check");
            GameObject.FindGameObjectWithTag("validateaudio").GetComponent<ValidAudioController>().ValidSound();
            gameCanvas.GetComponent<canvasSpeech>().showGreenCheck(true);
        }
        if (showX)
        {
            Debug.Log("Showing X");
            GameObject.FindGameObjectWithTag("validateaudio").GetComponent<ValidAudioController>().InvalidSound();
            gameCanvas.GetComponent<canvasSpeech>().showRedX(true);
        }
        timeSinceCheckOrX = 0;
        clearXAndCheckCalled = false;
    }
}
