using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalBase : MonoBehaviour
{
    
    [SerializeField] Text problemText;
    public string SetProblem(int level)
    {
        problemText.gameObject.SetActive(true);
        //Set Problem Text
        return "+";
    }

    public void CheckAnswer(string answer)
    {
        //Checks if answer is correct
    }
}
