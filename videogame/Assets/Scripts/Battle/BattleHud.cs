/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets and updates all information displayed as the battle hud
*/

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    //set all properties associated with the battle hud
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;
    [SerializeField] GameObject xpBar;

    Program _program;

    //be able to return hp bar publicly
    public HPBar HpBar {
        get {return hpBar;}
    }

    //set data depending on program parameter, such as level, name, hp and xp
    public void SetData(Program program)
    {
        _program = program;
        SetLevel();
        nameText.text = program.Base.Name;
        
        
        hpBar.SetHP((float)program.HP / program.MaxHp);
        SetXp();
        
    }

    //set level text
    public void SetLevel()
    {
        levelText.text = "Lvl " + _program.Level;
    }

    //set xp accordingly to player unit or enemy unit, and dont set it if it's an enemy unit
    public void SetXp()
    {
        if (xpBar == null) return;

        float normalizedXp = GetNormalizedXp();

        xpBar.transform.localScale = new Vector3(normalizedXp, 1, 1);
    }

    //return 0 or 1 based on normalized xp from current xp level and next xp level
    float GetNormalizedXp()
    {
        int currLevelXp = _program.Base.GetXpPerLevel(_program.Level);
        int nextLevelXp = _program.Base.GetXpPerLevel(_program.Level + 1);

        float normalizedXp = (float)(_program.Xp - currLevelXp) / (nextLevelXp - currLevelXp);

        return Mathf.Clamp01(normalizedXp);
    }

    //update hp bar smoothly based on hp and max hp
    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_program.HP / _program.MaxHp);
    }

    //set smooth update for xp bar, and level up based on reset value (resetting the xp bar as well)
    public IEnumerator SetXpSmooth(bool reset=false)
    {
        if (xpBar == null) yield break;

        if (reset)
            xpBar.transform.localScale = new Vector3(0, 1, 1);

        float normalizedXp = GetNormalizedXp();
        yield return xpBar.transform.DOScaleX(normalizedXp, 1.5f).WaitForCompletion();
    }
}
