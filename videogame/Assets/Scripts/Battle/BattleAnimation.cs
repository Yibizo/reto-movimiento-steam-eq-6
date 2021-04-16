/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script gets an animator component and is able to return it. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimation : MonoBehaviour
{
    //set animator property 
    Animator anim;
    
    //get component of animator 
    void Start ()
    {
        anim = GetComponent<Animator>();
    }

    //be able to return animator publicly
    public Animator Anim {
        get { return anim; }
    }
    
}
