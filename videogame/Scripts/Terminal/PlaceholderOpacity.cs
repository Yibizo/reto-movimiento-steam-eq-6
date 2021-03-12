using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceholderOpacity : MonoBehaviour
{
    [SerializeField] string textValue;
    [SerializeField] Text textElement;
    bool opacityValue = true;
    
    // Start is called before the first frame update
    void Start()
    {
        textElement.text = textValue;
        InvokeRepeating("Appear",0.7f,0.7f);
    }

    void Appear(){
        if(!DetectKey.instance.writingActive){
            if(!TerminalBackground.instance.correctAnswer){
                opacityValue = !opacityValue;
                textElement.gameObject.SetActive(opacityValue);
            }
            else{
                textElement.gameObject.SetActive(false);
                CancelInvoke();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(DetectKey.instance.writingActive){
            textElement.gameObject.SetActive(false);
        }
    }
}
