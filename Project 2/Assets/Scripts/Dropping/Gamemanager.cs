using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager manager;
    
    public float trash, trashpersec;
    //you get this amt of trash
    public float getTrash;
    //each var is holds amt of buildings for that type
    public float friend, garbageman;
    //cost to get the type of building
    public float friendcost, garbagemancost;
    //cost of next getTrash;
    public float getTrashCost;
    public float slideval, slidevalvis;
    public bool goingdown;
    public bool tutState;
    public int tutorialState;
    //special skill 1
    public float vaccumTime, vaccumTimeHold, vaccumTimeHoldCost, vacCooldown, vacCooldownHold, vacCooldownCost, hasVacSkill;
    //achievements and stats
    public float bestTrash;
    public float vacTimeAchivement; 
    //Prestige mechanics
    public float solarPanels;

    //music
    public bool MusicBool;
    public float MusicOnOff;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
        //tutState = true;
        goingdown = false;
        trash = 0;
        trashpersec = 0;
        friend = 0;
        garbageman = 0;
        getTrash = 1;
        getTrashCost = 10;
        friendcost = 15;
        garbagemancost = 100;
        vaccumTime = 0;
        vaccumTimeHold = 30;
        vaccumTimeHoldCost = 100;
        vacCooldown = 0;
        vacCooldownHold = 60;
        vacCooldownCost = 100;
        hasVacSkill = 0;
        //MusicOnOff = 1;
        //MusicBool = true;
    }

    // Update is called once per frame
    void Update()
    {

        Vaccum();
        if(goingdown == true)
        {
            slidevalvis -= 5 * Time.deltaTime;
        }

        if(tutorialState == 1)
        {
            tutState = true;
        }
        else if (tutorialState == 0)
        {
            tutState = false;
        }

        if(solarPanels > 0)
        {
            trash += trashpersec * Time.deltaTime * solarPanels;
        }
        else
        {
            trash += trashpersec * Time.deltaTime;
        }
        

        if(trash > bestTrash)
        {
            bestTrash = trash;
        }

        //if(MusicBool == true)
        //{
        //    MusicOnOff = 1;
        //}
        //else if(MusicBool == false)
        //{
        //    MusicOnOff = 0;
        //}
    }
    
    public void ResetGame()
    {
        goingdown = false;
        trash = 0;
        trashpersec = 0;
        friend = 0;
        garbageman = 0;
        getTrash = 1;
        getTrashCost = 10;
        friendcost = 15;
        garbagemancost = 100;
        vaccumTimeHold = 30;
        vaccumTimeHoldCost = 100;
        vacCooldown = 0;
        vacCooldownHold = 60;
        vacCooldownCost = 100;
        hasVacSkill = 0;
        
    }

    public void WipeGame()
    {
        bestTrash = 0;
        vacTimeAchivement = 0;
    }


    public void SwitchMusic()
    {
        if(MusicOnOff == 1)
        {
            MusicOnOff = 0;
        }
        else
        {
            MusicOnOff = 1;
        }
    }





    public void SaveData()
    {
        SaveDataSystem.SaveGameData(this);
    }
    public void LoadData()
    {
        StoreData data = SaveDataSystem.loadData();

        trash = data.trash;
        trashpersec = data.trashpersec;
        getTrash = data.getTrash;
        getTrashCost = data.getTrashCost;
        friend = data.friend;
        friendcost = data.friendcost;
        tutorialState = data.tutorialState;
        bestTrash = data.bestTrash;
        solarPanels = data.solarPanels;
        vaccumTimeHold = data.vaccumTimeHold;
        vaccumTimeHoldCost = data.vaccumTimeHoldCost;
        vacCooldown = data.vacCooldown;
        vacCooldownHold = data.vacCooldownHold;
        vacCooldownCost = data.vacCooldownCost;
        hasVacSkill = data.hasVacSkill;
        vacTimeAchivement = data.vacTimeAchivement;
        MusicOnOff = data.MusicOnOff;
    }

    private void Vaccum()
    {
        vaccumTime -= Time.deltaTime;
        if (vacCooldown <= 0)
        {
            vacCooldown = 0;
        }
        else
        {
            vacCooldown -= Time.deltaTime;
        }

        if(vaccumTime > 0)
        {
            vacTimeAchivement += Time.deltaTime;
        }
    }
}
