using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] ProgramBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public int Level {
        get {return level; }
    }

    public Program Program { get; set; }

    public void Setup()
    {
        
        Program = new Program(_base, level);
        GetComponent<Image>().sprite = Program.Base.FrontSprite;
        
    }
}
