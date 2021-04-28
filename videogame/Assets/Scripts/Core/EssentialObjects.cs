/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets up all essential objects to not destroy on load of a scene change
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjects : MonoBehaviour
{
    //don't destroy assigned game object
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
