using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public string titleScene;

    public void TitleScreen()
    {
        SceneManager.LoadScene(titleScene);
    }
}
