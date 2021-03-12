using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Program", menuName = "Program/Create new Program")]
public class ProgramBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;
    [SerializeField] Sprite frontSprite;


    [SerializeField] ProgramType type;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMoves> learnableMoves;

    public string Name {
        get { return name; }
    }

    public string Description {
        get { return description; }
    }

    public Sprite FrontSprite {
        get { return frontSprite; }
    }

    public ProgramType Type {
        get { return type; }
    }

    public int MaxHp {
        get { return maxHp; }
    }
    public int Attack {
        get { return attack; }
    }
    public int Defense {
        get { return defense; }
    }
    public int Speed {
        get { return speed; }
    }
    public List<LearnableMoves> LearnableMoves {
        get { return learnableMoves; }
    }

}

[System.Serializable]
public class LearnableMoves
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base {
        get { return moveBase; }
    }

    public int Level {
        get { return level; }
    }
}

public enum ProgramType
{
    None,
    Ally,
    Boss,
    Logic,
    Algebra
}
