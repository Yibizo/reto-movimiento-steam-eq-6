using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    [SerializeField] Text programText;
    [SerializeField] string textValue;
    [SerializeField] int lettersPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        programText.text = textValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
