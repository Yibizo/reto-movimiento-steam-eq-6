﻿/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets up terminal properties for current battle
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalBase : MonoBehaviour
{
    //set all properties associated with the terminal base
    [SerializeField] Text problemText;
    private List<ProblemBase> problems;

    private ProblemBase currProblem;

    //set problem according to player unit level and enemy unit program that returns its solution for future check
    public string SetProblem(int level, Program program)
    {
        problems = program.Base.Problems;
        currProblem = null;
        //set random problem from problems list
        while (currProblem == null)
        {
            if (problems[Random.Range(0, problems.Count)].Lvl <= level)
                currProblem = problems[Random.Range(0, problems.Count)];
        }

        problemText.gameObject.SetActive(true);
        //Set Problem Text
        problemText.text = currProblem.Description;

        return currProblem.Solution;
    }

    public void CheckAnswer(string answer)
    {
        //Checks if answer is correct
    }
}
