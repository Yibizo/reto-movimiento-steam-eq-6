/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script is the main game controller that performs its update checks and changes game states
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { FreeRoam, Battle, Dialog, Paused, GameOver }
public class GameController : MonoBehaviour
{
    //set all main game properties
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;
    Fader fader;
    [SerializeField] Dialog gameOverDialog;
    [SerializeField] Dialog StartGameDialog;
    [SerializeField] Dialog winGameDialog;
    bool gameOver = false;

    public static GameController Instance { get; private set; }

    GameState state;

    GameState prevState;

    //gets called before game object is enabled, where all game states are added accordingly, as well as the fader and an instance of itself
    private void Start()
    {
        StartCoroutine(DialogManager.Instance.ShowDialog(StartGameDialog));
        fader = FindObjectOfType<Fader>();

        Instance = this;
        playerController.OnEncounter += StartBattle;
        battleSystem.OnBattleEnd += EndBattle;
        DialogManager.Instance.OnShowDialog += () => 
        {
            state = GameState.Dialog;
        };

        DialogManager.Instance.OnCloseDialog += () => 
        {
            if (state == GameState.Dialog && !gameOver)
                state = GameState.FreeRoam;
        };
    }

    //change game state to paused according to its parameter 
    public void PauseGame(bool pause)
    {
        if (pause)
        {
            prevState = state;
            state = GameState.Paused;
        }
        else
        {
            state = prevState;
        }
    }

    //start battle, where battle system and its state is activated and world camera is deactivated
    //get program according to what was previously defined in the grid map and the player party
    //start battlesystem with both wild program and player party
    public void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);

        
        var wildProgram = FindObjectOfType<MapArea>().GetComponent<MapArea>().GetRandomWildProgram();
        var playerParty = playerController.GetComponent<ProgramParty>();
        

        battleSystem.StartBattle(wildProgram, playerParty);

    }

    //end battle and change state depending on if the player won or not
    //if the player won, change game state to freeroam and activate its world camera, deactivating the battle system as well
    //else, change game state to game over screen, where the coroutine for game over is started
    void EndBattle(bool won, bool winGame)
    {
        
        if (won && !winGame)
        {
            state = GameState.FreeRoam;
            battleSystem.gameObject.SetActive(false);
            worldCamera.gameObject.SetActive(true);
        }
        else if (!won && !winGame)
        {
            state = GameState.GameOver;
            gameOver = true;
            battleSystem.gameObject.SetActive(false);
            worldCamera.gameObject.SetActive(true);
            StartCoroutine(GameOver(false));

        }
        else if (won && winGame)
        {
            
            state = GameState.GameOver;
            gameOver = true;
            battleSystem.gameObject.SetActive(false);
            worldCamera.gameObject.SetActive(true);
            StartCoroutine(GameOver(true));

        }
    }

    //main game update function, where updates are called according to the current game state
    public void Update()
    {   
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
    }

    //show game over black screen and dialog text
    IEnumerator GameOver(bool winGame)
    {
        if (!winGame)
        {
            yield return fader.FadeIn(2f);
            yield return new WaitForSeconds(1f);
            yield return DialogManager.Instance.ShowDialog(gameOverDialog);
        }
        else if (winGame)
        {
            yield return fader.FadeIn(2f);
            yield return new WaitForSeconds(1f);
            yield return DialogManager.Instance.ShowDialog(winGameDialog);
        }
        
    }
}
