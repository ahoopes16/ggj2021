using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    private GameObject manager;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        time = manager.GetComponent<GameManager>().time;
        if(time == 0.0f) {
            return;
        }
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        GetComponent<UnityEngine.UI.Text>().text = string.Format("{0}:{1}", minutes, seconds);
        //GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("GameManager").GetComponent<GameManager>().time;
    }
}
