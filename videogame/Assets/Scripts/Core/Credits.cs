/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)
Modification Date: 27/04/21
Functionality: 
    This script is used to load title screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public string titleScene;

    //load title screen scene
    public void TitleScreen()
    {
        SceneManager.LoadScene(titleScene);
    }
}
