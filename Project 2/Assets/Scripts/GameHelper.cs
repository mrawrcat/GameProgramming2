using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameHelper : MonoBehaviour
{
    //public Text trashText, plasticText;
    //public Text collectorText, incTrashCapCostText;

    // these are the resources you can obtain
    public Text trashTxt, plasticTxt, aluminumTxt;
    public GameObject plasticTxtc, aluminumTxtc;
    public bool plasticbool, alumbool;
    //this is the amt of resources you can have of a resource
    //public Text trashCapTxt, plasCapTxt, alumCapTxt;
    //auto resource increasers
    //public Text trashCollectorsTxt, plasticCollectorsTxt, metalCollectorsTxt;
    //hires type cost
    public Text trashfriendcost, trashworkercost, trashgarbagemancost, trashorganizationcost;
    //resource cap modifiers -> increase cap by this much
    //public Text incrTrashCapTxt, incrPlasticCapTxt, incrAlumCapTxt;
    //resource requirement for cap modifiers
    public Text incrTrashCapCostTxt;
    //, incrCollectorCostTxt, incrPlasCapCostTxt, incrAlumCapCostTxt;
    //increase trash cap type cost
    //public Text trashfriendcostc, trashworkercostc, trashgarbagemancostc, trashorganizationcostc;
    public Slider bonusSlide;
    public GameObject content;
    public Button researchPlastic, researchAlum;


    private void Start()
    {
        GameManager.gmanager.LoadData();
        plasticbool = false;
    }
    private void Update()
    {
        
        //trashText.text = "Trash Collected: " + Mathf.Round(GameManager.gmanager.trash) + "/" + Mathf.Round(GameManager.gmanager.trashCap);
        //plasticText.text = "Plastic Obtained: " + Mathf.Round(GameManager.gmanager.plastic) + "/" + Mathf.Round(GameManager.gmanager.plasticCap);
        //collectorText.text = "Hired " + GameManager.gmanager.trashCollectors + " Collectors " + "This costs: " + GameManager.gmanager.increaseCollectorCost;
        //incTrashCapCostText.text = "Increase Trash Cap cost: " +  GameManager.gmanager.increaseTrashCapCost;

        ////////////////////
        ///

        trashTxt.text = "Trash: " + Mathf.Round(GameManager.gmanager.trash) + "/" + Mathf.Round(GameManager.gmanager.trashCap);
        plasticTxt.text = "Plastic Obtained: " + Mathf.Round(GameManager.gmanager.plastic) + "/" + Mathf.Round(GameManager.gmanager.plasticCap);
        aluminumTxt.text = "Aluminum Obtained: " + Mathf.Round(GameManager.gmanager.aluminum) + "/" + Mathf.Round(GameManager.gmanager.aluminumCap);
        //trashCapTxt.text = "trash Cap";
        //plasCapTxt.text = "plastic Cap";
        //alumCapTxt.text = "alum Cap";

        //trashCollectorsTxt.text = "trash collector amt";

        trashfriendcost.text = "Costs: " + GameManager.gmanager.trashfriendcost + " Trash";
        trashworkercost.text = "Costs: " + GameManager.gmanager.trashworkercost + " Trash";
        trashgarbagemancost.text = "Costs: " + GameManager.gmanager.trashgarbagemancost + " Trash";
        trashorganizationcost.text = "Costs: " + GameManager.gmanager.trashorganizationcost + " Trash";

        //incrTrashCapTxt.text = "increase trash cap by this much";
        //incrPlasticCapTxt.text = "increase plastic cap by this much";
        //incrAlumCapTxt.text = "increase alum by this much";

        incrTrashCapCostTxt.text = "Costs: " + GameManager.gmanager.increaseTrashCapCost + " Trash";
        //incrCollectorCostTxt.text = "cost to hire collector";
        //incrPlasCapCostTxt.text = "cost to increase plastic cap";
        //incrAlumCapCostTxt.text = "cost to increase alumnium";

        bonusSlide.value = GameManager.gmanager.bonusVisual;

        resourceActive();

        content.GetComponent<RectTransform>().sizeDelta = new Vector2(GameManager.gmanager.contentSizeX, GameManager.gmanager.contentSizeY);
        if (GameManager.gmanager.unlockedPlastic == true)
        {
            researchPlastic.interactable = false;
        }
        else
        {
            researchPlastic.interactable = true;
        }

        if (GameManager.gmanager.unlockedAlum == true)
        {
            researchAlum.interactable = false;
        }
        else
        {
            researchAlum.interactable = true;
        }
    }
    public void AddTrash(float val)
    {
        if (GameManager.gmanager.trash < GameManager.gmanager.trashCap)
        {
            GameManager.gmanager.trash += val;
        }

    }
    
    
    private void AddTrashCollector(float val)
    {
            GameManager.gmanager.trashCollectors += val;
    }
    private void AddPlasticCollector(float val)
    {
        GameManager.gmanager.plasticCollectors += val;
    }
    private void AddAlumCollector(float val)
    {
        GameManager.gmanager.metalCollectors += val;
    }

    public void AddTrashFriend()
    {
        if (GameManager.gmanager.trash >= GameManager.gmanager.trashfriendcost)
        {
            GameManager.gmanager.trash -= GameManager.gmanager.trashfriendcost;
            AddTrashCollector(1);
            GameManager.gmanager.trashfriendcost += GameManager.gmanager.trashfriendcost / 3;
        }
            
    }

    public void AddPlasticFriend()
    {
        if(GameManager.gmanager.trash >= GameManager.gmanager.plasticfriendcost)
        {
            GameManager.gmanager.trash -= GameManager.gmanager.plasticfriendcost;
            AddPlasticCollector(1);
            GameManager.gmanager.plasticfriendcost += GameManager.gmanager.plasticfriendcost / 3;
        }
    }
    public void ResearchPlastic()
    {
        if (GameManager.gmanager.trash >= GameManager.gmanager.plasticfriendcost)
        {
            GameManager.gmanager.trash -= GameManager.gmanager.plasticfriendcost;
            AddPlasticCollector(1);
            GameManager.gmanager.plasticfriendcost += GameManager.gmanager.plasticfriendcost / 3;
            GameManager.gmanager.unlockedPlastic = true;
        }
    }
    public void ResearchAlum()
    {
        if (GameManager.gmanager.trash >= GameManager.gmanager.alumfriendcost)
        {
            if(GameManager.gmanager.plastic >= 100)
            {
                GameManager.gmanager.trash -= GameManager.gmanager.alumfriendcost;
                GameManager.gmanager.plastic -= 100;
                AddAlumCollector(1);
                GameManager.gmanager.alumfriendcost += GameManager.gmanager.alumfriendcost / 3;
                GameManager.gmanager.unlockedAlum = true;
                //content.GetComponent<RectTransform>().sizeDelta = new Vector2(900,150);
                GameManager.gmanager.contentSizeX = 900;
                
            }
            
        }
    }
    public void IncreaseTrashCap()
    {
        //ok shouldnt use trash to expand trashcap maybe use plastic or metal
        if (GameManager.gmanager.trash >= GameManager.gmanager.increaseTrashCapCost)
        {
            GameManager.gmanager.trash -= GameManager.gmanager.increaseTrashCapCost;
            GameManager.gmanager.trashCap += GameManager.gmanager.increaseTrashCap;
            GameManager.gmanager.increaseTrashCapCost += GameManager.gmanager.increaseTrashCapCost/2;
        }

    }
    public void IncreasePlasticCap()
    {
        if(GameManager.gmanager.trash >= GameManager.gmanager.increasePlasCapCost)
        {
            GameManager.gmanager.trash -= GameManager.gmanager.increasePlasCapCost;
            GameManager.gmanager.plasticCap += GameManager.gmanager.increasePlasticCap;
            GameManager.gmanager.increasePlasCapCost += GameManager.gmanager.increasePlasCapCost + GameManager.gmanager.increasePlasCapCost / 2;

        }
    }
    public void resetGame()
    {
        GameManager.gmanager.ResetGame();
        plasticbool = false;
        alumbool = false;
        plasticTxtc.SetActive(false);
        aluminumTxtc.SetActive(false);
    }
    private void resourceActive()
    {
        if(GameManager.gmanager.plastic >= 1)
        {
            plasticbool = true;
            
        }
        if(plasticbool == true)
        {
            plasticTxtc.SetActive(true);
        }
        if(GameManager.gmanager.aluminum >= 1)
        {
            alumbool = true;
        }
        if (alumbool == true)
        {
            aluminumTxtc.SetActive(true);
        }
    }
    void OnApplicationQuit()
    {
        GameManager.gmanager.SaveData();
    }
}
