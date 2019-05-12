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
    //special skills
    public Text vacCooldown , vacDesc, bestVacTime;
    public Button vacSkill, getVacSkill;
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
        vacCooldown.text = Gamemanager.manager.vacCooldown.ToString("F0");
        bestVacTime.text = "Vaccum Time: " + Gamemanager.manager.vacTimeAchivement;

        VaccumSkill();
        
    }

   
    public void getVaccumSkill()
    {
        if(Gamemanager.manager.trash >= 1000)
        {
            Gamemanager.manager.trash -= 1000;
            Gamemanager.manager.hasVacSkill = 1;
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
    private void VaccumSkill()
    {
        //vaccumskill
        if(Gamemanager.manager.hasVacSkill <= 0)
        {
            vacSkill.interactable = false;
            getVacSkill.interactable = true;
        }
        if (Gamemanager.manager.vacCooldown > 0)
        {
            vacSkill.interactable = false;
            vacCooldown.gameObject.SetActive(true);
        }
        else if(Gamemanager.manager.vacCooldown <= 0 && Gamemanager.manager.hasVacSkill >= 1)
        {
            getVacSkill.interactable = false;
            vacSkill.interactable = true;
            vacCooldown.gameObject.SetActive(false);
            vacDesc.gameObject.SetActive(true);
        }
    }
}
