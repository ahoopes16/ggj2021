using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasFinalScore : MonoBehaviour
{
    private GameObject finalScore;

    private void Start()
    {
        finalScore = transform.Find("FinalScore").gameObject;
        HideFinalScore();
    }

    public void HideFinalScore()
    {
        finalScore.SetActive(false);
    }

    public void ShowFinalScore()
    {
        finalScore.SetActive(true);
    }
}
