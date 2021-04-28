/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script controls properties of NPCs, currently containing only dialog
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    //set all properties associated with the NPC
    [SerializeField] Dialog dialog;

    //show freeroam text box based on dialog assigned
    public void Interact()
    {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
