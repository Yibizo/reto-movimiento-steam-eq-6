using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int time;
    [SerializeField] string textValue;
    [SerializeField] Text textElement;
    [SerializeField] InputField inputField;
    [SerializeField] Text inputText;
    public static Timer instance;
    public bool timeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        textElement.text = textValue;
        InvokeRepeating("Counter",0,1);
    }

    void Counter(){
        if(time != 0){
            if(time < 10){
                textElement.text = $"Tiempo: 0{time} segundos";
            }
            else{
                textElement.text = $"Tiempo: {time} segundos";
            }
            time--;
        }
        else{
            Time.timeScale = 0;
            textElement.text = "Tiempo agotado";
            inputField.gameObject.SetActive(false);
            inputText.gameObject.SetActive(false);
            timeOut = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TerminalBackground.instance.correctAnswer == true){
            CancelInvoke("Counter");
        }
    }
}
