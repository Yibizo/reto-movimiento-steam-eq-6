/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets portals to be used and linked between scenes
*/

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    //set all properties associated with the portal
    //load first scene by default
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] DestinationIdentifier destinationPortal;

    PlayerController player;

    //when player collides with triggers, start switch scene function
    public void OnPlayerTriggered(PlayerController player)
    {
        this.player = player;
        StartCoroutine(SwitchScene());
    }

    //set up fader object
    Fader fader;

    //assign fader as first fader object type found
    private void Start()
    {
        fader = FindObjectOfType<Fader>();
    }

    //function to switch scene, where essential objects are not destoyed on load but instead loaded into the next linked scene
    IEnumerator SwitchScene()
    {
        DontDestroyOnLoad(gameObject);

        GameController.Instance.PauseGame(true);

        yield return fader.FadeIn(0.5f);

        yield return SceneManager.LoadSceneAsync(sceneToLoad+1);

        //get portal destination
        //define facing direction and position with spawn point 
        var destPortal = FindObjectsOfType<Portal>().First(x => x != this && x.destinationPortal == this.destinationPortal);
        player.SetPositionAndSnapToTile(destPortal.spawnPoint.position);

        yield return fader.FadeOut(0.5f);

        GameController.Instance.PauseGame(false);

        Destroy(gameObject);
    }

    //get spawn point publicly
    public Transform SpawnPoint => spawnPoint;
}

//destination indentifiers to be linked with letters
public enum DestinationIdentifier{A, B, C, D, E, F, G, H, I, J}