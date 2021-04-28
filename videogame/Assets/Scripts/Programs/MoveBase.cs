/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets up base of moves as scriptable objects
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//menu to create scriptable object
[CreateAssetMenu(fileName = "Move", menuName = "Program/Create new move")]
public class MoveBase : ScriptableObject
{
    //set all properties associated with the move base
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int power;
    [SerializeField] int accuracy;

    //functions to return move base properties publicly
    public string Name {
        get { return name; }
    }

    public string Description {
        get { return description; }
    }

    public int Power {
        get { return power; }
    }

    public int Accuracy {
        get { return accuracy; }
    }

}
