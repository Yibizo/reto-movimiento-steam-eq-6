using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string newGameScene;
    public string creditsScene;

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void Credits()
    {
        SceneManager.LoadScene(creditsScene);
    }
}
