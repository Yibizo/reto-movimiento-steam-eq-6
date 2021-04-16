/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets up the program party, which only consists of the player unit 
*/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgramParty : MonoBehaviour
{
    //set up list of programs
    [SerializeField] List<Program> programs;

    //function to publicly get list of programs
    public List<Program> Programs{
        get { return programs; }
    }

    //function that initializes all programs in program party
    private void Start()
    {
        foreach (var program in programs)
        {
            program.Init();
        }
    }

    //set default program to be used in combat as the first one
    public Program GetHealthyProgram()
    {
        return programs.Where(x => x.HP > 0).FirstOrDefault();
    }

}
