using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    public Text trashtxt, trashpersec, trashperclick;
    public Slider slide;
    //Text for Shop
    public Text incrTrash;
    public Text bestTrash;
    public Text bonusTrash, bonusTrashCost;
    public Button getMoreBonusBtn;
    //special skills
    
   
    public GameObject[] particles;
    public int currentparticle, reset;


    // Start is called before the first frame update
    void Start()
    {
        Gamemanager.manager.LoadData();
        //counts number of particle gameobjects. actual resetting done in clickTrash
       foreach(GameObject part in particles)
       {
            reset++;
       }
    }

    // Update is called once per frame
    void Update()
    {
        trashtxt.text = "Trash: " + Gamemanager.manager.trash.ToString("F1");
        trashpersec.text = "Trash/Sec: " + Gamemanager.manager.trashpersec.ToString("F2") ;
        slide.value = Gamemanager.manager.slidevalvis;
        trashperclick.text = Gamemanager.manager.getTrash + " Per Pick Up";
        incrTrash.text = "Costs: " + Gamemanager.manager.getTrashCost.ToString("F2");
        bestTrash.text = "Highest Amount of Trash Recycled: " + Gamemanager.manager.bestTrash.ToString("F2") + " Trash";
        bonusTrash.text = "+" + Gamemanager.manager.bonusTrash.ToString("F1");
        bonusTrashCost.text = "Costs: " + Gamemanager.manager.bonusTrashCost.ToString("F2");

        moreBonus();
        
    }

    private void moreBonus()
    {
        if (Gamemanager.manager.trash >= Gamemanager.manager.bonusTrashCost)
        {
            getMoreBonusBtn.interactable = true;
        }
        else
        {
            getMoreBonusBtn.interactable = false;
        }
    }


    public void increaseVaccumTime()
    {
        if(Gamemanager.manager.trash >= Gamemanager.manager.vaccumTimeHoldCost)
        {
            Gamemanager.manager.trash -= Gamemanager.manager.vaccumTimeHoldCost;
            Gamemanager.manager.vaccumTimeHold += 5;
            Gamemanager.manager.vaccumTimeHoldCost *= 1.4f;
        }
    }
    public void decreaseVaccumCooldown()
    {
        if (Gamemanager.manager.trash >= Gamemanager.manager.vacCooldownCost)
        {
            Gamemanager.manager.trash -= Gamemanager.manager.vacCooldownCost;
            Gamemanager.manager.vacCooldownHold -= 1;
            Gamemanager.manager.vaccumTimeHoldCost *= 1.4f;
        }
    }

    public void getMoreBonus()
    {
        if(Gamemanager.manager.trash >= Gamemanager.manager.bonusTrashCost)
        {
            Gamemanager.manager.trash -= Gamemanager.manager.bonusTrashCost;
            Gamemanager.manager.bonusTrash += 30;
            Gamemanager.manager.bonusTrashCost += Gamemanager.manager.bonusTrashCost / 2;
        }
    }

    public void resetGame()
    {
        Gamemanager.manager.ResetGame();
    }
    public void wipeAchieve()
    {
        Gamemanager.manager.WipeGame();
    }


    private void OnApplicationQuit()
    {
        Gamemanager.manager.SaveData();
    }
    
    
}
