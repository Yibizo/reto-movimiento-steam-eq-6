/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets up move object for battle units
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    //assign a set and get for MoveBase
    public MoveBase Base { get; set; }

    //to add base move to battle unit
    public Move(MoveBase pBase)
    {
        Base = pBase;
    }
}
