using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneswitcher : MonoBehaviour
{
    private void Awake() {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name != "game") {
            GameObject.FindGameObjectWithTag("menuaudio").GetComponent<PlayBetweenScenes>().PlayMusic();
        } else {
            GameObject.FindGameObjectWithTag("menuaudio").GetComponent<PlayBetweenScenes>().StopMusic();
            
        }
        GameObject.FindGameObjectWithTag("buttonaudio").GetComponent<PlayBetweenScenes>().PlayMusic();
    }

    public void ToGame() {
        SceneManager.LoadScene("game");
    }

    public void ToTitle() {
        SceneManager.LoadScene("title");
    }

    public void ToCredits() {
        SceneManager.LoadScene("credits");
    }
}
