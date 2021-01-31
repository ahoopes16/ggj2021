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

    // Start is called before the first frame update
    void Start()
    {
        speechBubble = transform.Find("bubble").gameObject;
        clueOne = transform.Find("Clue1").gameObject;
        clueTwo = transform.Find("Clue2").gameObject;
        clueThree = transform.Find("Clue3").gameObject;

        clearSpeechBubble();
    }

    public void clearSpeechBubble()
    {
        speechBubble.SetActive(false);
        clueOne.SetActive(false);
        clueTwo.SetActive(false);
        clueThree.SetActive(false);
    }

    public void setClueOne(string clue)
    {
        Debug.Log($"Setting clue one to {clue}");
        speechBubble.SetActive(true);
        clueOne.GetComponent<Text>().text = clue;
        clueOne.SetActive(true);
    }

    public void setClueTwo(string clue)
    {
        clueTwo.GetComponent<Text>().text = clue;
        clueTwo.SetActive(true);
    }

    public void setClueThree(string clue)
    {
        clueThree.GetComponent<Text>().text = clue;
        clueThree.SetActive(true);
    }
}
