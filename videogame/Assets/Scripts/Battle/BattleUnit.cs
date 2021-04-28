/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script defines all properties and animations of a battle unit
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    //set all properties associated with the battle unit
    [SerializeField] bool isPlayerUnit;
    private int level;

    public int Level {
        get {return level; }
    }

    //function to get and set program properties out of this script 
    public Program Program { get; set; }

    Image image;
    Vector3 ogPos;
    Animator animator;
    Color ogColor;
    
    //get original image position and color, as well as animator component
    private void Awake()
    {
        image = GetComponent<Image>();
        ogPos = image.transform.localPosition;
        animator = GetComponent<Animator>();
        ogColor = image.color;
    }

    //setup the type of program (player or enemy), as well as its level, sprite and play an enter animation for enemy unit
    public void Setup(Program program)
    {
        
        Program = program;
        level = program.Level;
        GetComponent<Image>().sprite = Program.Base.FrontSprite;


        image.color = ogColor;
        PlayEnterAnimation();

    }

    //play enter animation from left to right
    public void PlayEnterAnimation()
    {
        image.transform.localPosition = new Vector3(-480f, ogPos.y);
        
        image.transform.DOLocalMoveX(ogPos.x, 1f);
    }

    //play animation when enemy takes a hit, where it blinks from original color to gray
    public void PlayEnemyHitAnimation()
    {
        var sequence = DOTween.Sequence();
        SoundManager.Instance.playSoundEffect(SoundManager.Instance.HitSound);
        sequence.Append(image.DOColor(Color.gray, 0.1f));
        sequence.Append(image.DOColor(ogColor, 0.1f));
        sequence.Append(image.DOColor(Color.gray, 0.1f));
        sequence.Append(image.DOColor(ogColor, 0.1f));
        
    }

    //play enemy faint animation, where it goes from original position to down, and fades them out
    public void PlayFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        SoundManager.Instance.playSoundEffect(SoundManager.Instance.FaintSound);
        sequence.Append(image.transform.DOLocalMoveY(ogPos.y - 150f, 0.5f));
        sequence.Join(image.DOFade(0f, 0.5f));
    }

    //play enemy attack animation, where it goes in the sequence up -> down -> original position
    public void PlayAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(ogPos.y + 50, 1f));
        sequence.Append(image.transform.DOLocalMoveY(ogPos.y - 50, 0.30f));
        sequence.Append(image.transform.DOLocalMoveY(ogPos.y, 1f));
    }
}