using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleActionBox : MonoBehaviour
{
    [SerializeField] GameObject actionSelector;
    [SerializeField] Color hightlightedColor;

    [SerializeField] List<Text> actionTexts;

    public void EnableActionText(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

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
