/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script assigns program stats and properties to current battle units in action
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Program
{
    //set all properties associated with the program in battle system
    [SerializeField] ProgramBase _base;
    [SerializeField] int level;
    int prevMaxHp;

    //functions to return program properties 
    public ProgramBase Base {
        get {
            return _base;
        }
    }

    public int Level {
        get {
            return level;
        }
    }

    //functions that also set program properties
    public int HP { get; set; }
    public List<Move> Moves { get; set; }

    public Dictionary<Stat, int> Stats { get; private set; }

    public int Xp { get; set; }

    //check if gained xp exceeds current player xp, and level them up if true
    public bool CheckForLevelUp()
    {
        if (Xp > Base.GetXpPerLevel(level + 1))
        {
            ++level;
            return true;
        }

        return false;
    }

    //return stat from list of stats
    int GetStat(Stat stat)
    {
        int statVal = Stats[stat];

        return statVal;
    }

    //return stat specified from list of stats
    public int Attack {
        get { return GetStat(Stat.Attack); }
    }

    public int Defense {
        get { return GetStat(Stat.Defense); }
    }

    public int Speed {
        get { return GetStat(Stat.Speed); }
    }

    //get and privately set current max hp
    public int MaxHp { get; private set;}

    //initializer for program, where moves are assigned and stats are calculated before battle
    public void Init()
    {
        //generate moves
        Moves = new List<Move>();
        foreach (var move in Base.LearnableMoves)
        {
            if(move.Level <= Level)
                Moves.Add(new Move(move.Base));

            if (Moves.Count >= 4)
                break;
        }
        CalculateStats(false);

        HP = MaxHp;

        Xp = Base.GetXpPerLevel(Level);

    }

    //function that calculates and assigns proogram stats based on level
    public void CalculateStats(bool isLevelUp)
    {
        //create new stat dictionary where the stats and their corresponding value are created
        Stats = new Dictionary<Stat, int>();
        Stats.Add(Stat.Attack, Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5);
        Stats.Add(Stat.Defense, Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5);
        Stats.Add(Stat.Speed, Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5);
        
        //if player is leveled up, set previous max hp to current max hp
        if (isLevelUp)
            prevMaxHp = MaxHp;

        //calculate new max hp
        MaxHp = Mathf.FloorToInt((Base.Attack * Level) / 100f) + 10;

        //if player is leveled up, add difference of max hp and previous max hp to current hp
        if(isLevelUp)
            HP += MaxHp - prevMaxHp; 
    }

    public bool TakeDamage(MoveBase move, Program attacker)
    {
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if(HP <= 0)
        {
            HP = 0;
            return true;
        }
        return false;
    }

    public void OnBattleOver()
    {

    }
}
