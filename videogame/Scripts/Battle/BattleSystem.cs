using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy }

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;
    [SerializeField] BattleActionBox actionBox;
    [SerializeField] TerminalBase terminal;
    [SerializeField] InputField inputField;
    [SerializeField] GameObject consoleAnim;

    string correctAnswer;
    string playerAnswer;

    BattleState state;

    int currentAction;

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        enemyUnit.Setup();
        playerUnit.Setup();
        enemyHud.SetData(enemyUnit.Program);
        playerHud.SetData(playerUnit.Program);

        
        yield return dialogBox.TypeDialog($"A {enemyUnit.Program.Base.Name} has appeared!");

        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose and action"));
        actionBox.EnableActionText(true);
    }

    private void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            HandleTerminalTyping();
        }
    }

    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentAction < 1)
                ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentAction > 0)
                --currentAction;
        }

        actionBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {
                //Fight
                PlayerMove();
            }
            else if (currentAction == 1)
            {
                //Run
            }
        }
    }

    private void EnableTerminal(bool enabled)
    {
        terminal.gameObject.SetActive(enabled);
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        EnableTerminal(true);
        actionBox.EnableActionText(false);
        StartCoroutine(dialogBox.TypeDialog("Solve the problem!"));
        consoleAnim.SetActive(false);
        correctAnswer = terminal.SetProblem(playerUnit.Level);
        inputField.gameObject.SetActive(true);
    }

    void HandleTerminalTyping()
    {
        //Use InputField
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            Debug.Log("Hello2");
            playerAnswer = inputField.text;
            Debug.Log("Hello");

            if (playerAnswer == correctAnswer)
            {
                //Correct
                StartCoroutine(dialogBox.TypeDialog("Correct!"));
                enemyHud.HpBar.SetHP(0f);
            }
            else
            {
                //Incorrect
                StartCoroutine(dialogBox.TypeDialog("Incorrect!"));
                playerHud.HpBar.SetHP(0f);
            }
            
            inputField.text = string.Empty;
        }
        

        
    }
}
