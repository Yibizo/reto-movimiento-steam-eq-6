/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script establishes all program enemies per map area
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{
    //setup the list of all possible wild programs that can appear
    [SerializeField] List<Program> wildPrograms;

    //get random wild program from wild programs list, and initialize its moves and stats
    public Program GetRandomWildProgram()
    {
        var wildProgram = wildPrograms[Random.Range(0, wildPrograms.Count)];
        wildProgram.Init();
        return wildProgram;
    }


}
