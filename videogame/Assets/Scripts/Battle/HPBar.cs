/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script is used for hp bar updates and hud scrolls
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;

    //set scale for hp
    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
    }

    //set hp change smoothly based on new hp given
    public IEnumerator SetHPSmooth(float newHp)
    {
        float curHp = health.transform.localScale.x;
        float changeAmt = curHp - newHp;

        while (curHp - newHp > Mathf.Epsilon)
        {
            curHp -= changeAmt * Time.deltaTime;
            health.transform.localScale = new Vector3(curHp, 1f);
            yield return null;
        }
        health.transform.localScale = new Vector3(newHp, 1f);
    }
}
