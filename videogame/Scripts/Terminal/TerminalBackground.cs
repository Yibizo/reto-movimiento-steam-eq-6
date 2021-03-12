using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalBackground : MonoBehaviour
{
    [SerializeField] Text textElement;
    public static TerminalBackground instance;
    int counterTime = 0;
    public bool answered = false;
    public bool correctAnswer = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(DetectKey.instance.inputAnswer != string.Empty){
            answered = true;
            if(DetectKey.instance.inputAnswer == "+"){//correct answer
                textElement.gameObject.SetActive(true);
                textElement.text = "Correcto";
                textElement.color = new Color(53/255f,115/255f,17/255f,0.5f);//green half opacity
                correctAnswer = true;
            }
            else if(DetectKey.instance.inputAnswer != string.Empty){
                textElement.gameObject.SetActive(true);//incorrect answer
                textElement.text = "Incorrecto";
                textElement.color = new Color(156/255f,8/255f,8/255f,0.5f);//red half opacity
            }
        }
        if(answered){
            answered = false;
            InvokeRepeating("Counter",1,1);
        }
    }

    void Counter(){
        counterTime++;
        if(counterTime == 1){
            counterTime = 0;
            textElement.gameObject.SetActive(false);
            DetectKey.instance.inputAnswer = string.Empty;
            CancelInvoke();
        }
    }

}
