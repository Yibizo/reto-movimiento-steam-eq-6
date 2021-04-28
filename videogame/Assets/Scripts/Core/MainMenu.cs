/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)
    
Modification Date: 27/04/21

Functionality: 
    This script is used to load a new game and the credits from the title screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string newGameScene;
    public string creditsScene;

    //load new game
    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    //load credits scene
    public void Credits()
    {
        SceneManager.LoadScene(creditsScene);
    }
}
