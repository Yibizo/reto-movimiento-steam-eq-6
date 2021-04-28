using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingStationController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    public void Interact()
    {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        var playerParty = FindObjectOfType<ProgramParty>();
        var playerProgram = playerParty.GetHealthyProgram();
        
        playerProgram.HP = playerProgram.MaxHp;
    }
}