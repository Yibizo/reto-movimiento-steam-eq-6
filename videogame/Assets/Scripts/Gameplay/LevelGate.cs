/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)
    
Modification Date: 15/04/21

Functionality: 
    This script involves all level gate logic when interacted with
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGate : MonoBehaviour, Interactable
{
    //define dialog and required level to access
    [SerializeField] Dialog dialog;
    [SerializeField] Dialog dialogSuccess;
    [SerializeField] Dialog dialogFailure;

    [SerializeField] int reqlevel;

    //function that when interacted, get player program and check if player is equal or higher to the required level
    //if true, disable game object
    public void Interact()
    {
        var playerParty = FindObjectOfType<ProgramParty>();
        var playerProgram = playerParty.GetHealthyProgram();

        StartCoroutine(Dialog(playerProgram));

        
    }

    //function that displays dialog and checks level
    IEnumerator Dialog(Program playerProgram)
    {
        yield return DialogManager.Instance.ShowDialog(dialog);
        yield return new WaitForSeconds(2f);
        Checker(playerProgram);
    }

    //function to check level and define gate action
    void Checker(Program playerProgram)
    {
        if (playerProgram.Level >= reqlevel)
        {
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.CorrectAnswer);
            //Sets gameobjects as active
            gameObject.SetActive(false);
        }
        else
        {
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.HitSound);
        }

    }
    
}
