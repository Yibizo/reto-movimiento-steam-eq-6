/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script controls all movement and interactions involving the player character
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //set all properties associated with the player character

    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;
    public LayerMask encounterTiles;

    public event Action OnEncounter;

    private bool isMoving;

    private Vector2 input;
    
    private Animator animator;

    //adjust position to nearest tile and get animator component
    private void Awake()
    {
        SetPositionAndSnapToTile(transform.position);
        animator = GetComponent<Animator>();
    }

    //main update for player controller
    public void HandleUpdate()
    {
        SoundManager.Instance.normalBackgroundMusic();

        //if the player is not moving
        if(!isMoving)
        {
            //update input
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //don't allow diagonal movement
            if (input.x != 0) input.y = 0;

            //give position properties for the animator, and check whether the player can move to target position
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                //see if target position is walkable in order to change player position
                if (isWalkable(targetPos))
                    StartCoroutine(Move(targetPos));

                
            }
        }

        //set animator parameter to isMoving
        animator.SetBool("isMoving", isMoving);

        //if player presses 'z', run interact function
        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    //detect if player is colliding with a trigger
    private void OneMoveOver()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, GameLayers.i.TriggerableLayers);

        foreach (var collider in colliders)
        {
            var triggerable = collider.GetComponent<IPlayerTriggerable>();
            //if triggerable is found, trigger accordingly and break out of loop
            if (triggerable != null)
            {
                triggerable.OnPlayerTriggered(this);
                break;
            }
        }
    }

    //interact function that only functions if the player is facing correctly
    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, interactableLayer);
        //if player is colliding, isMoving is false and interact with said collider
        if (collider != null)
        {
            isMoving = false;
            collider.GetComponent<Interactable>()?.Interact();
        }

    }

    //move function that transforms position according to tiles
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
        
        OneMoveOver();
    }

    //detect if tile is walkable
    private bool isWalkable(Vector3 targetPos)
    {
        //if solid object or interactable is null, not walkable
        //else walkable
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        return true;
    }

    //snap player character to nearest tile
    public void SetPositionAndSnapToTile(Vector2 pos)
    {
        pos.x = Mathf.Floor(pos.x) + 0.5f;
        pos.y = Mathf.Floor(pos.y) + 0.5f;

        transform.position = pos;
    }


}
