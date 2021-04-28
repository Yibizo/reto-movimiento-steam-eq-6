using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGate : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    [SerializeField] Dialog dialogSuccess;
    [SerializeField] Dialog dialogFailure;

    [SerializeField] int reqlevel;

    public void Interact()
    {
        var playerParty = FindObjectOfType<ProgramParty>();
        var playerProgram = playerParty.GetHealthyProgram();

        StartCoroutine(Dialog(playerProgram));

        
    }

    IEnumerator Dialog(Program playerProgram)
    {
        yield return DialogManager.Instance.ShowDialog(dialog);
        yield return new WaitForSeconds(2f);
        Checker(playerProgram);
    }

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
