/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets up dialog to be used as serializable
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    //assign how many lines of string for dialog
    [SerializeField] List<string> lines;

    //return lines as a list of strings
    public List<string> Lines {
        get { return lines; }
    }
}
