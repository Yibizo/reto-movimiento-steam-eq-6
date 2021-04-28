/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script involves all of the logic involving the battle system
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//set all posibles battle states
public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy, BattleOver }

public class BattleSystem : MonoBehaviour
{
    //set all properties associated with the battle system
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;
    [SerializeField] BattleActionBox actionBox;
    [SerializeField] TerminalBase terminal;
    [SerializeField] InputField inputField;
    [SerializeField] BattleAnimation consoleAnim;
    [SerializeField] MoveBase move;
    [SerializeField] List<ProblemBase> problems;

    int currentArea;
    int currentAreaIdx;

    wwwFormGameData sendGameData;
    

    public event Action<bool, bool> OnBattleEnd;

    List<string> correctAnswer;
    
    string playerAnswer;

    BattleState state;

    int currentAction = 0;
    int runAttempts;
    int problemsTotal;
    int problemsArea1;
    int problemsArea2;
    int problemsArea3;

    Program wildProgram;
    ProgramParty playerParty;

    //start battle using wild program and player party
    public void StartBattle(Program wildProgram, ProgramParty playerParty)
    {
        this.wildProgram = wildProgram;
        this.playerParty = playerParty;
        StartCoroutine(SetupBattle());
        sendGameData = GameObject.Find("GameController").GetComponent<wwwFormGameData>();
    }

    //set up all components from enemy and player units
    public IEnumerator SetupBattle()
    {
        problemsTotal = 0;
        runAttempts = 0;
        problemsArea1 = 0;
        problemsArea2 = 0;
        problemsArea3 = 0;

        SoundManager.Instance.isInCombat = true;

        //Setup all unit in the battle system
        enemyUnit.Setup(wildProgram);
        playerUnit.Setup(playerParty.GetHealthyProgram());
        enemyHud.SetData(enemyUnit.Program);
        playerHud.SetData(playerUnit.Program);

        yield return dialogBox.TypeDialog($"A {enemyUnit.Program.Base.Name} has appeared!");

        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    //perform player action, where gamestate changes to player action
    void PlayerAction()
    {
        inputField.gameObject.SetActive(false);
        terminal.gameObject.SetActive(false);
        consoleAnim.gameObject.SetActive(true);
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        actionBox.EnableActionText(true);
    }

    //update action according to battle state
    public void HandleUpdate()
    {
        SoundManager.Instance.battleBackgroundMusic(enemyUnit.Program.Base.Name);
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            
            HandleTerminalTyping();
        }
    }

    //define if the battle is over, where the boolean defines if the player won or not 
    void BattleOver(bool won)
    {
        state = BattleState.BattleOver;
        //return last level
        Debug.Log(playerUnit.Program.Level);

        //return last area
        Debug.Log(currentAreaIdx);

        if (problemsArea1 > 0)
        {
            int tempSuccess1 = (int)(((float)(problemsArea1)/(float)(problemsTotal))*100);
            playerUnit.Program.SuccessRate1 += tempSuccess1;
            playerUnit.Program.AreaEncounters1++;
            playerUnit.Program.TotalEncounters1 = (int)((float)(playerUnit.Program.SuccessRate1)/(float)(playerUnit.Program.AreaEncounters1));
        }
        else if (problemsArea2 > 0)
        {
            int tempSuccess2 = (int)(((float)(problemsArea2)/(float)(problemsTotal))*100);
            playerUnit.Program.SuccessRate2 += tempSuccess2;
            playerUnit.Program.AreaEncounters2++;
            playerUnit.Program.TotalEncounters2 = (int)((float)(playerUnit.Program.SuccessRate2)/(float)(playerUnit.Program.AreaEncounters2));
        }
        else if (problemsArea3 > 0)
        {
            int tempSuccess3 = (int)(((float)(problemsArea3)/(float)(problemsTotal))*100);
            playerUnit.Program.SuccessRate3 += tempSuccess3;
            playerUnit.Program.AreaEncounters3++;
            playerUnit.Program.TotalEncounters3 = (int)((float)(playerUnit.Program.SuccessRate3)/(float)(playerUnit.Program.AreaEncounters3));
        }

        //return total success rate per area
        Debug.Log(playerUnit.Program.TotalEncounters1);
        Debug.Log(playerUnit.Program.TotalEncounters2);
        Debug.Log(playerUnit.Program.TotalEncounters3);

        StartCoroutine(sendGameData.UpdateData(playerUnit.Program.Level, currentAreaIdx, playerUnit.Program.TotalEncounters1, playerUnit.Program.TotalEncounters2, playerUnit.Program.TotalEncounters3));

        OnBattleEnd(won, false);
    }

    //move across fight and run options, highlight selected option, and perform functions based on selection
    void HandleActionSelection()
    {
        //move across options
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.MenuSelect1);
            if (currentAction < 1)
                ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.MenuSelect1);
            if (currentAction > 0)
                --currentAction;
        }

        //highlight selected option
        actionBox.UpdateActionSelection(currentAction);

        //perform selected action
        if (Input.GetKeyDown(KeyCode.Z) && !dialogBox.IsTyping)
        {
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.MenuSelect1);
            if (currentAction == 0)
            {
                //Fight
                PlayerMove();
            }
            else if (currentAction == 1 && !dialogBox.IsTyping)
            {
                //Run
                StartCoroutine(PlayerRun());
                
            }
        }
    }

    //function to enable terminal
    private void EnableTerminal(bool enabled)
    {
        terminal.gameObject.SetActive(enabled);
    }

    //player run function, where battle state changes to busy to not be interrupted 
    IEnumerator PlayerRun()
    {
        state =  BattleState.Busy;

        dialogBox.setTyping(true);

        //calculate run chance if f is higher than random number generated 
        int F = (((playerUnit.Program.Speed * 128)/enemyUnit.Program.Speed) + 30 * runAttempts) % 256;
        
        //based on calculation, let the player exit the battle or add a run attempt and perform enemy move
        if (UnityEngine.Random.Range(0, 256) < F || playerUnit.Program.Speed > enemyUnit.Program.Speed)
        {
            SoundManager.Instance.isInCombat = false;
            SoundManager.Instance.stopMusic();
            
            yield return dialogBox.TypeDialog("You got away safely...");
            yield return new WaitForSeconds(1f);
            
            BattleOver(true);
            
        }
        else
        {
            runAttempts++;
            yield return PerformEnemyMove(true);
        }
    }

    //player move where the terminal and its components are activated 
    void PlayerMove()
    {
        
        state = BattleState.PlayerMove;
        EnableTerminal(true);
        actionBox.EnableActionText(false);
        StartCoroutine(dialogBox.TypeDialog("Solve the problem!"));
        consoleAnim.gameObject.SetActive(false);
        
        //To be done
        correctAnswer = terminal.SetProblem(playerUnit.Level, problems);
        
        inputField.gameObject.SetActive(true);
    }

    //function that occurs when the player inputs the correct answer
    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;
        //Correct
        inputField.gameObject.SetActive(false);
        SoundManager.Instance.playSoundEffect(SoundManager.Instance.CorrectAnswer);
        yield return dialogBox.TypeDialog("Correct!");
        yield return new WaitForSeconds(0.5f);
        yield return dialogBox.TypeDialog("You attack the virus!");
        yield return new WaitForSeconds(1f);

        //add counter to problems of each area
        currentArea = SceneManager.GetActiveScene().buildIndex-1;
        if (GameController.Instance.Area1Idx.IndexOf(currentArea) != -1)
        {
            currentAreaIdx = 1;
            problemsArea1++;
        }
        else if (GameController.Instance.Area2Idx.IndexOf(currentArea) != -1)
        {
            currentAreaIdx = 2;
            problemsArea2++;
        }
        else if (GameController.Instance.Area3Idx.IndexOf(currentArea) != -1)
        {
            currentAreaIdx = 3;
            problemsArea3++;
        }

        enemyUnit.PlayEnemyHitAnimation();
        bool isFainted = enemyUnit.Program.TakeDamage(move, playerUnit.Program);

        yield return enemyHud.UpdateHP();
        
        //check if the enemy unit was defeated
        //if true, deactivate the terminal and update the xp and level accordingly
        //else continue with player action
        if (isFainted)
        {
            SoundManager.Instance.isInCombat = false;
            SoundManager.Instance.stopMusic();
            //XP Gain

            //---------------------------------------
            
            if (enemyUnit.Program.Base.Name == "Boss3-Virus")
            {
                OnBattleEnd(true, true);
            }
            
            //---------------------------------------


            int xpYield = enemyUnit.Program.Base.XpYield;
            int enemyLevel = enemyUnit.Program.Level;

            int xpGain = Mathf.FloorToInt((xpYield * enemyLevel) / 7);

            yield return dialogBox.TypeDialog($"{enemyUnit.Program.Base.Name} was defeated!");
            
            enemyUnit.PlayFaintAnimation();
            inputField.gameObject.SetActive(false);
            terminal.gameObject.SetActive(false);
            yield return new WaitForSeconds(2f);
            playerUnit.Program.Xp += xpGain;
            yield return dialogBox.TypeDialog($"{playerUnit.Program.Base.Name} gained {xpGain} XP!");

            yield return playerHud.SetXpSmooth();
            
            //check if player has leveled up
            while (playerUnit.Program.CheckForLevelUp())
            {
                playerHud.SetLevel();
                playerUnit.Program.CalculateStats(true);
                SoundManager.Instance.playSoundEffect(SoundManager.Instance.CorrectAnswer);
                yield return dialogBox.TypeDialog($"{playerUnit.Program.Base.Name} leveled up!");
                yield return playerHud.SetXpSmooth(true);
            }

            yield return new WaitForSeconds(2f);
            BattleOver(true);
        }
        else
        {
            PlayerAction();
        }
        
    }

    //function of enemy unit attack, where hp of player unit is updated accordingly and check whether it is a run attempt or incorrect answer
    //deactivate terminal and perform enemy attack and player hit animations
    IEnumerator PerformEnemyMove(bool isRunAttempt)
    {
        state = BattleState.EnemyMove;
        //Incorrect
        inputField.gameObject.SetActive(false);

        if (isRunAttempt == false)
            StartCoroutine(dialogBox.TypeDialog("Incorrect!"));
            
        else if (isRunAttempt == true)
            StartCoroutine(dialogBox.TypeDialog("You failed to run away!"));

        SoundManager.Instance.playSoundEffect(SoundManager.Instance.IncorrectAnswer);
            
        inputField.gameObject.SetActive(false);
        terminal.gameObject.SetActive(false);
        consoleAnim.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(dialogBox.TypeDialog("The virus attacked you!"));
        yield return new WaitForSeconds(1f);
        enemyUnit.PlayAttackAnimation();
        consoleAnim.Anim.SetTrigger("isHit");
        yield return new WaitForSeconds(1f);
        consoleAnim.Anim.SetTrigger("isHit");
        
        //PlayerHitAnimation
        bool isFainted = playerUnit.Program.TakeDamage(move, enemyUnit.Program);

        yield return playerHud.UpdateHP();

        //if fainted, end the battle where the player didn't win
        //else continue with player action
        if (isFainted)
        {
            SoundManager.Instance.isInCombat = false;
            SoundManager.Instance.stopMusic();
            yield return dialogBox.TypeDialog($"{playerUnit.Program.Base.Name} was defeated!");
            inputField.gameObject.SetActive(false);
            terminal.gameObject.SetActive(false);
            
            yield return new WaitForSeconds(2f);
            BattleOver(false);
        }
        else
        {
            PlayerAction();
        }

    }

    //detect key downs, where 'tab' activates the input field and 'enter' checks for the correct answer and resets the input field
    void HandleTerminalTyping()
    {
        //use input field
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.MenuSelect2);
            inputField.ActivateInputField();
        }

        //get answer
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.MenuSelect3);
            playerAnswer = inputField.text;
            problemsTotal++;

            if (correctAnswer.Contains(playerAnswer))
            {
                
                StartCoroutine(PerformPlayerMove());
            }
            else
            {
                StartCoroutine(PerformEnemyMove(false));
            }
            
            inputField.text = string.Empty;
        }
        

        
    }

}
