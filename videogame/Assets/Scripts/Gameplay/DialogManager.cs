/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 27/04/21

Functionality: 
    This script handles how the dialog is being used
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    //set all properties associated with the dialog manager
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    
    bool isTyping;
    Dialog dialog;
    int currentLine = 0;

    //activate dialog box and type dialog
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();

        OnShowDialog?.Invoke();

        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    //update current line until there are no lines to display
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.MenuSelect2);
            //if counter is less than lines, display current dialog line
            //else deactivate dialog box and reset counter
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                currentLine = 0;
                dialogBox.SetActive(false);
                OnCloseDialog?.Invoke();
            }
        }
    }

    //type current dialog text given from parameter with a time of defined letter per second
    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            SoundManager.Instance.playSoundEffect(SoundManager.Instance.TextSound);
            dialogText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
        isTyping = false;
    }


}
