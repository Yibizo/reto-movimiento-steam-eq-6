/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script highlights what action is currently selected by the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleActionBox : MonoBehaviour
{
    //set all properties associated with the battle action box
    [SerializeField] GameObject actionSelector;
    [SerializeField] Color hightlightedColor;

    [SerializeField] List<Text> actionTexts;

    //activate action box text
    public void EnableActionText(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    //update action box text depending on parameter
    public void UpdateActionSelection(int selectedAction)
    {
        for (int i=0; i<actionTexts.Count; i++)
        {
            if (i==selectedAction)
                actionTexts[i].color = hightlightedColor;
            else
                actionTexts[i].color = Color.black;

        }
    }
}
