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
    public float friend, garbageman, organization, government, cult;
    //cost to get the type of building
    public float friendcost, garbagemancost, orgcost, govcost, cultcost;
    //check to see if color should be black or white
    public float org_bw, gov_bw, cult_bw;
    //cost of next getTrash;
    public float getTrashCost;
    public float slideval, slidevalvis;
    public bool goingdown;

    //tutorial stuff
    public bool activateThisIsShop, thisIsShopWasActive, activateUpgrade, upgradeWasActive;
    public int helloWelcome, clickOnTrash, thisIsUpgrade, firstUpgrade, thisIsShop, firstHire;
    public int shopActivated, upgradeActivated;
    public int statsTut, prestigeTut;
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
        
        goingdown = false;
        trash = 0;
        trashpersec = 0;
        friend = 0;
        garbageman = 0;
        organization = 0;
        government = 0;
        cult = 0;

        getTrash = 1;
        getTrashCost = 10;


        friendcost = 15;
        garbagemancost = 100;
        orgcost = 1000;
        govcost = 100000;
        cultcost = 1000000;

        org_bw = 0;
        gov_bw = 0;
        cult_bw = 0;

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

        if(trash >= 9)
        {
            activateUpgrade = true;
        }
        if(trash >= 14)
        {
            activateThisIsShop = true;
        }
        if(shopActivated == 1)
        {
            thisIsShopWasActive = true;
        }
        else
        {
            thisIsShopWasActive = false;
        }
        if (upgradeActivated == 1)
        {
            upgradeWasActive = true;
        }
        else
        {
            upgradeWasActive = false;
        }

        if (Gamemanager.manager.trash >= Gamemanager.manager.orgcost)
        {
            Gamemanager.manager.org_bw = 1;
        }
        if (Gamemanager.manager.trash >= Gamemanager.manager.govcost)
        {
            Gamemanager.manager.gov_bw = 1;
        }
        if (Gamemanager.manager.trash >= Gamemanager.manager.cultcost)
        {
            Gamemanager.manager.cult_bw = 1;
        }

    }
    
    public void ResetGame()
    {
        goingdown = false;
        trash = 0;
        trashpersec = 0;
        friend = 0;
        garbageman = 0;
        organization = 0;
        government = 0;
        cult = 0;

        getTrash = 1;
        getTrashCost = 10;

        friendcost = 15;
        garbagemancost = 100;
        orgcost = 1000;
        govcost = 100000;
        cultcost = 1000000;

        org_bw = 0;
        gov_bw = 0;
        cult_bw = 0;

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
        garbageman = data.garbageman;
        organization = data.organization;
        government = data.government;
        cult = data.cult;




        friendcost = data.friendcost;
        garbagemancost = data.garbagemancost;
        orgcost = data.orgcost;
        govcost = data.govcost;
        cultcost = data.cultcost;


        org_bw = data.org_bw;
        gov_bw = data.gov_bw;
        cult_bw = data.cult_bw;

        //tutorial
        helloWelcome = data.helloWelcome;
        clickOnTrash = data.clickOnTrash;
        thisIsShop = data.thisIsShop;
        firstHire = data.firstHire;
        thisIsUpgrade = data.thisIsUpgrade;
        firstUpgrade = data.firstUpgrade;
        statsTut = data.statsTut;
        prestigeTut = data.prestigeTut;
        shopActivated = data.shopActivated;
        upgradeActivated = data.upgradeActivated;

        //achievements
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
