using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gmanager;

    // these are the resources you can obtain
    public float trash, plastic, aluminum;
    //this is the amt of resources you can have of a resource
    public float trashCap, plasticCap, aluminumCap;
    //auto resource increasers
    public float trashCollectors, plasticCollectors, metalCollectors;
    //hires
    public float trashfriendcost, trashworkercost, trashgarbagemancost, trashorganizationcost;
    public float plasticfriendcost, plasticworkercost, plasticgarbagemancost, plasticorganizationcost;
    public float alumfriendcost, alumworkercost, alumgarbagemancost, alumorganizationcost;
    //resource cap modifiers -> increase cap by this much --> might be obsolete
    public float increaseTrashCap, increasePlasticCap, increaseAlumCap;
    //resource requirement for cap modifiers
    public float increaseTrashCapCost, increaseCollectorCost, increasePlasCapCost, increaseAlumCapCost;
    //stuff for getting bonus boost?
    public float bonusVisual, bonusCount, bonusMulti;
    //increase trash cap type cost
    public float trashfriendcostc, trashworkercostc, trashgarbagemancostc, trashorganizationcostc;
    //resource unlocked or not
    public bool unlockedPlastic, unlockedAlum;
    public float contentSizeX = 800, contentSizeY = 150;
    void Awake()
    {
        if (gmanager == null)
        {
            gmanager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (gmanager != this)
        {
            Destroy(gameObject);
        }
        trashCap = 500;
        plasticCap = 200;
        aluminumCap = 100;
        trashCollectors = 0;
        plasticCollectors = 0;
        metalCollectors = 0;

        trashfriendcost = 10;
        trashworkercost = 100;
        trashgarbagemancost = 1000;
        trashorganizationcost = 100000;

        plasticfriendcost = 1000;

        alumfriendcost = 3000;

        increaseTrashCap = 500;
        increaseTrashCapCost = 10;
        increaseCollectorCost = 10;
        bonusVisual = 0;
        bonusCount = 0;
        bonusMulti = 1;

        unlockedPlastic = false;
        unlockedAlum = false;
        
        contentSizeX = 800;
        contentSizeY = 150;
        
    }
    private void Update()
    {
        if(bonusVisual <= 0)
        {
            bonusVisual = 0;
        }
        if(trash < trashCap)
        {
            trash += trashCollectors * bonusMulti* Time.deltaTime;
        }
        if (plastic < plasticCap)
        {
            plastic += plasticCollectors * bonusMulti * Time.deltaTime;
        }
        if (aluminum < aluminumCap)
        {
            aluminum += metalCollectors * bonusMulti * Time.deltaTime;
        }
    }
    public void ResetGame()
    {
        //SceneManager.LoadScene(0);
        trash = 0;
        plastic = 0;
        aluminum = 0;

        trashCollectors = 0;
        plasticCollectors = 0;
        metalCollectors = 0;

        trashfriendcost = 10;
        trashworkercost = 100;
        trashgarbagemancost = 1000;
        trashorganizationcost = 100000;

        plasticfriendcost = 1000;

        trashCap = 500;
        plasticCap = 200;
        increaseTrashCap = 500;
        increaseTrashCapCost = 10;
        increaseCollectorCost = 10;
        bonusCount = 0;
        bonusVisual = 0;
        bonusMulti = 1;

        unlockedPlastic = false;
        unlockedAlum = false;

        contentSizeX = 800;
        contentSizeY = 150;
        
        
    }

    public void SaveData()
    {
        SaveSystem.SaveGameData(this);
    }
    public void LoadData()
    {
        GameData data = SaveSystem.loadData();

        trash = data.trash;
        plastic = data.plastic;
        aluminum = data.aluminum;

        trashCap = data.trashCap;
        plasticCap = data.plasticCap;

        trashCollectors = data.trashCollectors;
        plasticCollectors = data.plasticCollectors;
        trashfriendcost = data.trashfriendcost;

        plasticfriendcost = data.plasticfriendcost;
        increaseTrashCap = data.increaseTrashCap;

        increaseTrashCapCost = data.increaseTrashCapCost;
        increaseCollectorCost = data.increaseCollectorCost;

        unlockedPlastic = data.unlockedPlastic;
        unlockedAlum = data.unlockedAlum;

        contentSizeX = data.contentSizeX;
        contentSizeY = data.contentSizeY;
    }
   
}
