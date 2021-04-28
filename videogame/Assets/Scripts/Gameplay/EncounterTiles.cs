/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script handles encounter tile behaviour on player collide
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterTiles : MonoBehaviour, IPlayerTriggerable
{
    //start a battle if random number generated triggered from entering an encounter tile is less than or equal to 10
    public void OnPlayerTriggered(PlayerController player)
    {
        
        if (UnityEngine.Random.Range(1,101) <= 20)
            {
                
                GameController.Instance.StartBattle();
            }
    }
}
