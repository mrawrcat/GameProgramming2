using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameHelper : MonoBehaviour
{
    public Text trashText, plasticText;
    public Text collectorText, incTrashCapCostText;

    // these are the resources you can obtain
    public Text trashTxt, plasticTxt, aluminumTxt;
    //this is the amt of resources you can have of a resource
    public Text trashCapTxt, plasCapTxt, alumCapTxt;
    //auto resource increasers
    public Text trashCollectorsTxt;
    //resource cap modifiers -> increase cap by this much
    public Text incrTrashCapTxt, incrPlasticCapTxt, incrAlumCapTxt;
    //resource requirement for cap modifiers
    public Text incrTrashCapCostTxt, incrCollectorCostTxt, incrPlasCapCostTxt, incrAlumCapCostTxt;

    public Slider bonusSlide;

    private void Start()
    {
        GameManager.gmanager.LoadData();
    }
    private void Update()
    {
        trashText.text = "Trash Collected: " + Mathf.Round(GameManager.gmanager.trash) + "/" + Mathf.Round(GameManager.gmanager.trashCap);
        plasticText.text = "Plastic Obtained: " + Mathf.Round(GameManager.gmanager.plastic) + "/" + Mathf.Round(GameManager.gmanager.plasticCap);
        collectorText.text = "Hired " + GameManager.gmanager.trashCollectors + " Collectors " + "This costs: " + GameManager.gmanager.increaseCollectorCost;
        incTrashCapCostText.text = "Increase Trash Cap cost: " +  GameManager.gmanager.increaseTrashCapCost;

        ////////////////////
        ///

        trashTxt.text = Mathf.Round(GameManager.gmanager.trash) + "/" + Mathf.Round(GameManager.gmanager.trashCap);
        plasticTxt.text = Mathf.Round(GameManager.gmanager.plastic) + "/" + Mathf.Round(GameManager.gmanager.plasticCap);
        aluminumTxt.text = "Aluminum";
        trashCapTxt.text = "trash Cap";
        plasCapTxt.text = "plastic Cap";
        alumCapTxt.text = "alum Cap";

        trashCollectorsTxt.text = "trash collector amt";

        incrTrashCapTxt.text = "increase trash cap by this much";
        incrPlasticCapTxt.text = "increase plastic cap by this much";
        incrAlumCapTxt.text = "increase alum by this much";

        incrTrashCapCostTxt.text = "cost to increase trash cap";
        incrCollectorCostTxt.text = "cost to hire collector";
        incrPlasCapCostTxt.text = "cost to increase plastic cap";
        incrAlumCapCostTxt.text = "cost to increase alumnium";

        bonusSlide.value = GameManager.gmanager.bonusVisual;
    }
    public void AddTrash(float val)
    {
        if (GameManager.gmanager.trash < GameManager.gmanager.trashCap)
        {
            GameManager.gmanager.trash += val;
        }

    }
    public void SortTrash(float val)
    {
        if (GameManager.gmanager.trash >= 2 && GameManager.gmanager.plastic < GameManager.gmanager.plasticCap)
        {
            GameManager.gmanager.trash -= 2;
            GameManager.gmanager.plastic += val;
        }
    }
    public void AddTrashCollector(float val)
    {
        if (GameManager.gmanager.trash >= GameManager.gmanager.increaseCollectorCost)
        {
            GameManager.gmanager.trash -= GameManager.gmanager.increaseCollectorCost;
            GameManager.gmanager.trashCollectors += val;
            GameManager.gmanager.increaseCollectorCost += GameManager.gmanager.increaseCollectorCost + GameManager.gmanager.increaseCollectorCost/3f;
        }

    }
    public void IncreaseTrashCap()
    {
        //ok shouldnt use trash to expand trashcap maybe use plastic or metal
        if (GameManager.gmanager.trash >= GameManager.gmanager.increaseTrashCapCost)
        {
            GameManager.gmanager.trash -= GameManager.gmanager.increaseTrashCapCost;
            GameManager.gmanager.trashCap += GameManager.gmanager.increaseTrashCap;
            GameManager.gmanager.increaseTrashCapCost += GameManager.gmanager.increaseTrashCapCost + GameManager.gmanager.increaseTrashCapCost/2;
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
    }
    void OnApplicationQuit()
    {
        GameManager.gmanager.SaveData();
    }
}
