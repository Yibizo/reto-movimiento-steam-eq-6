/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script defines a functions for a group of IPlayerTriggerable, currently only with onPlayerTriggered
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerTriggerable
{
    //function of onPlayerTriggered, using the player controller
    void OnPlayerTriggered(PlayerController player);
}
