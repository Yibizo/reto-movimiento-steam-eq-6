using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    public HPBar HpBar {
        get {return hpBar;}
    }

    public void SetData(Program program)
    {
        
        
        nameText.text = program.Base.Name;
        levelText.text = "Lvl " + program.Level;
        
        hpBar.SetHP((float)program.HP / program.MaxHp);
        
        
    }
}
