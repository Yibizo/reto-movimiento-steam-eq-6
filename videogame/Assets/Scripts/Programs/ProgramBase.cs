/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script sets up base of programs as scriptable objects
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//menu to create scriptable object
[CreateAssetMenu(fileName= "Program", menuName = "Program/Create new Program")]

public class ProgramBase : ScriptableObject
{

    //set all properties associated with the program base
    [SerializeField] string name;
    

    [TextArea]
    [SerializeField] string description;
    [SerializeField] Sprite frontSprite;


    [SerializeField] ProgramType type;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;

    [SerializeField] int xpYield;
    
    [SerializeField] List<LearnableMoves> learnableMoves;

    //functions to publicly get program base properties
    public int GetXpPerLevel(int level)
    {
        //get xp by level^3
        return level * level * level;
    }

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
    public int XpYield {
        get { return xpYield; }
    }
    public List<LearnableMoves> LearnableMoves {
        get { return learnableMoves; }
    }

}

//set list of learnable move as a program property, where the size and problems containing it are assigned
[System.Serializable]
public class LearnableMoves
{
    //set ll properties associated with the learnable moves
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    //functions to publicly get learnable moves propertied
    public MoveBase Base {
        get { return moveBase; }
    }

    public int Level {
        get { return level; }
    }
}

//identify the type of program with enum
public enum ProgramType
{
    None,
    Ally,
    Boss,
    Logic,
    Algebra
}

//identify program stat with enum
public enum Stat
{
    Attack,
    Defense,
    Speed,
}


