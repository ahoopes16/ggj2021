using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasSpeech : MonoBehaviour
{
    private GameObject speechBubble;
    private GameObject clueOne;
    private GameObject clueTwo;
    private GameObject clueThree;
    private GameObject startingMessage;
    private GameObject janitor;
    private GameObject redX;
    private GameObject greenCheck;

    // Start is called before the first frame update
    void Start()
    {
        speechBubble = transform.Find("bubble").gameObject;
        clueOne = transform.Find("Clue1").gameObject;
        clueTwo = transform.Find("Clue2").gameObject;
        clueThree = transform.Find("Clue3").gameObject;
        startingMessage = transform.Find("StartingMessage").gameObject;
        janitor = transform.Find("Janitor").gameObject;
        redX = transform.Find("RedX").gameObject;
        greenCheck = transform.Find("GreenCheck").gameObject;

        ClearSpeechBubble();
    }

    public void ClearSpeechBubble()
    {
        speechBubble.SetActive(false);
        clueOne.SetActive(false);
        clueTwo.SetActive(false);
        clueThree.SetActive(false);
        startingMessage.SetActive(false);
        janitor.SetActive(false);
        redX.SetActive(false);
        greenCheck.SetActive(false);
    }

    public void SetClueOne(string clue)
    {
        Debug.Log($"Setting clue one to {clue}");
        speechBubble.SetActive(true);
        clueOne.GetComponent<Text>().text = clue;
        clueOne.SetActive(true);
    }

    public void SetClueTwo(string clue)
    {
        clueTwo.GetComponent<Text>().text = clue;
        clueTwo.SetActive(true);
    }

    public void SetClueThree(string clue)
    {
        clueThree.GetComponent<Text>().text = clue;
        clueThree.SetActive(true);
    }

    public void ShowStartMessage()
    {
        speechBubble.SetActive(true);
        startingMessage.SetActive(true);
        janitor.SetActive(true);
    }

    public void showRedX(bool value)
    {
        redX.SetActive(value);
    }

    public void showGreenCheck(bool value)
    {
        greenCheck.SetActive(value);
    }
}
