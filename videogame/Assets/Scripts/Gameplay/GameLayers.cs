/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script defines all of the game's layers
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    //setup all of the possible layers within the game
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask encounterLayer;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask portalLayer;

    public static GameLayers i { get; set; }

    //instance of itself
    private void Awake()
    {
        i = this;
    }

    //publicly get all possible layers
    public LayerMask SolidLayer {
        get => solidObjectsLayer;
    }
    public LayerMask InteractableLayer {
        get => interactableLayer;
    }
    public LayerMask EncounterLayer {
        get => encounterLayer;
    }
    public LayerMask PlayerLayer {
        get => playerLayer;
    }
    public LayerMask PortalLayer {
        get => portalLayer;
    }

    //assign encounter and portal layer as triggerable
    public LayerMask TriggerableLayers {
        get => encounterLayer | portalLayer;
    }

}
