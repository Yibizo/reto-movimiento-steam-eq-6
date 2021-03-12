using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DetectKey : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text inputText;
    [SerializeField] Text activeText;
    public static DetectKey instance;
    public string input;
    public string inputAnswer;
    public bool writingActive = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TerminalBackground.instance.correctAnswer && !Timer.instance.timeOut){
            //activate terminal using tab
            if(Input.GetKeyDown(KeyCode.Tab)){
                inputField.ActivateInputField();
                activeText.gameObject.SetActive(true);
                writingActive = true;
                
            }
            //get value in input field using Enter
            else if(Input.GetKeyDown(KeyCode.Return)){
                inputAnswer = inputText.text;
                inputText.text = string.Empty;
                inputField.text = string.Empty;
                activeText.gameObject.SetActive(false);
                writingActive = false;
            }
        }
        else{
            inputField.gameObject.SetActive(false);
            writingActive = false;
        }
    }
}