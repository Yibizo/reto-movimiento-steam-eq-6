/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)
    
Modification Date: 27/04/21

Functionality: 
    This script defines what interacting with a healing station does
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingStationController : MonoBehaviour, Interactable
{
    //healing station dialog
    [SerializeField] Dialog dialog;

    //function that when interacted with, get player program and equal their health to their max health
    public void Interact()
    {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        var playerParty = FindObjectOfType<ProgramParty>();
        var playerProgram = playerParty.GetHealthyProgram();
        
        playerProgram.HP = playerProgram.MaxHp;
    }
}