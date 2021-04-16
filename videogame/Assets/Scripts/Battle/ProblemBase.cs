/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets up programming problems as scriptable objects 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//menu to create scriptable object
[CreateAssetMenu(fileName= "Problem", menuName = "Problem/Create new Problem")]
[System.Serializable]
public class ProblemBase : ScriptableObject
{
    //set all properties associated with the problem base
    [SerializeField] string name;
    [SerializeField] int lvl;
    [SerializeField] string solution;

    [TextArea]
    [SerializeField] string description;
    

    //return functions to get problem base properties publicly
    public string Name {
        get { return name; }
    }

    public string Description {
        get { return description; }
    }

    public int Lvl {
        get { return lvl; }
    }

    public string Solution {
        get { return solution; }
    }

    
}
