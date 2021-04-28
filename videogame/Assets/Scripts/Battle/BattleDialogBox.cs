/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script defines battle dialog box properties and how to display dialog while on battle system
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    //set all properties associated with the battle dialog box
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;
    bool isTyping;

    //get is typing boolean
    public bool IsTyping {
        get {return isTyping;}
    }

    //set dialog text
    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    //type dialog based on string parameter and letters per second variable 
    public IEnumerator TypeDialog(string dialog)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.TextSound);
            dialogText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
        isTyping = false;
    }

    //enable dialog text based on parameter
    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    //set is typing boolean based on parameter
    public void setTyping(bool typing)
    {
        isTyping = typing;
    }
    
}