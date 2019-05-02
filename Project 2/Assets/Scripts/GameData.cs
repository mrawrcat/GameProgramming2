using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    // these are the resources you can obtain
    public float trash, plastic, aluminum;
    //this is the amt of resources you can have of a resource
    public float trashCap, plasticCap, aluminumCap;
    //auto resource increasers
    public float trashCollectors;
    //resource cap modifiers -> increase cap by this much
    public float increaseTrashCap, increasePlasticCap, increaseAlumCap;
    //resource requirement for cap modifiers
    public float increaseTrashCapCost, increaseCollectorCost, increasePlasCapCost, increaseAlumCapCost;
    //bonus
    public float bonusCount, bonusVisual, bonusMulti;

    public GameData(GameManager gmanager)
    {
        trash = gmanager.trash;
        plastic = gmanager.plastic;
        aluminum = gmanager.aluminum;

        trashCap = gmanager.trashCap;
        plasticCap = gmanager.plasticCap;
        aluminumCap = gmanager.aluminumCap;

        trashCollectors = gmanager.trashCollectors;

        increaseTrashCap = gmanager.increaseTrashCap;
        increasePlasticCap = gmanager.increasePlasticCap;
        increaseAlumCap = gmanager.increaseAlumCap;

        increaseTrashCapCost = gmanager.increaseTrashCapCost;
        increaseCollectorCost = gmanager.increaseCollectorCost;
        increasePlasCapCost = gmanager.increasePlasCapCost;
        increaseAlumCapCost = gmanager.increaseAlumCapCost;

        bonusCount = gmanager.bonusCount;
        bonusVisual = gmanager.bonusVisual;
        bonusMulti = gmanager.bonusMulti;

    }
}
