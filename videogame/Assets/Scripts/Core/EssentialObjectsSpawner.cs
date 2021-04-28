/*
Authors:
    - Jorge Cabiedes (A01024053)
    - Diego Mejía (A01024228)
    - Enrique Mondelli (A01379363)
    - José Salgado (A01023661)

Modification Date: 15/04/21

Functionality: 
    This script spawns essential objects on scene
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjectsSpawner : MonoBehaviour
{
    //set up essential objects prefab as a game object
    [SerializeField] GameObject essentialObjectsPrefab;

    //if essential objects are not found, load them
    private void Awake()
    {
        var existingObjects = FindObjectsOfType<EssentialObjects>();
        if (existingObjects.Length == 0)
            Instantiate(essentialObjectsPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
