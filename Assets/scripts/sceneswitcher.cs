using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneswitcher : MonoBehaviour
{
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
