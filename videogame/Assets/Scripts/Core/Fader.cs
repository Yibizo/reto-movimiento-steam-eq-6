/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script controls the fade animation of an image
*/

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class Fader : MonoBehaviour
{
    //assign image to animate as a fader
    Image image;

    //get image component
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    //fade in from opacity 0 to 1, and wait for it to end
    public IEnumerator FadeIn(float time)
    {
        yield return image.DOFade(1f, time).WaitForCompletion();
    }

    //fade in from opacity 1 to 0, and wait for it to end
    public IEnumerator FadeOut(float time)
    {
        yield return image.DOFade(0f, time).WaitForCompletion();
    }
    
}
