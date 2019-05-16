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
    public float bonusTrash, bonusTrashCost;
    //check to see if color should be black or white
    public float org_bw, gov_bw, cult_bw;
    //cost of next getTrash;
    public float getTrashCost;
    public float slideval, slidevalvis;
    public bool goingdown;

    //get more trash stuff
    public float moreTrash1, moreTrash2;
    //tutorial stuff
    public int helloWelcome, thisIsUpgrade, thisIsShop;
    public int shopActivated, upgradeActivated;
    public int statsTut, prestigeTut;
    public int statsActivated, prestigeActivated;
    //special skill 1
    public float vaccumTime, vaccumTimeHold, vaccumTimeHoldCost, vacCooldown, vacCooldownHold, vacCooldownCost, hasVacSkill;
    //special skill 2
    public float truckCooldown, truckCooldownHold, truckCooldownCost, hasTruckSkill;
    //special skill 3
    public float handTime, handTimeHold, handTimeHoldCost, handCooldown, handCooldownHold, handCooldownCost, hasHandSkill;
    //achievements and stats
    public float bestTrash;
    public float vacTimeAchivement, truckTimeAchivement, handTimeAchivement;
    //Prestige mechanics
    public float solarPanels;

    //music
    public bool MusicBool;
    public float MusicOnOff, sfxOnOff;

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
        vacCooldownHold = 45;
        vacCooldownCost = 100;
        hasVacSkill = 0;

        moreTrash1 = 0;
        moreTrash2 = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vaccum();
        Truck();
        Hand();

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

        


        //shop item can show or not
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

        bonusTrash = 30;
        bonusTrashCost = 30;
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

        //skill 1
        vaccumTimeHold = 30;
        vaccumTimeHoldCost = 100;
        vacCooldown = 0;
        vacCooldownHold = 45;
        vacCooldownCost = 100;
        hasVacSkill = 0;

        //skill 2
        truckCooldown = 0;
        truckCooldownHold = 60;
        truckCooldownCost = 100;
        hasTruckSkill = 0;

        //skill 3
        handTimeHold = 30;
        handTimeHoldCost = 100;
        handCooldown = 0;
        handCooldownHold = 90;
        handCooldownCost = 100;
        hasHandSkill = 0;

        //more trash
        moreTrash1 = 0;
        moreTrash2 = 0;
    }

    public void WipeGame()
    {
        bestTrash = 0;
        vacTimeAchivement = 0;
        truckTimeAchivement = 0;
        handTimeAchivement = 0;
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

    public void SwitchSFX()
    {
        if(sfxOnOff == 1)
        {
            sfxOnOff = 0;
        }
        else
        {
            sfxOnOff = 1;
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


        bonusTrash = data.bonusTrash;
        bonusTrashCost = data.bonusTrashCost;

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
        thisIsShop = data.thisIsShop;
        thisIsUpgrade = data.thisIsUpgrade;
        
        statsTut = data.statsTut;
        prestigeTut = data.prestigeTut;
        shopActivated = data.shopActivated;
        upgradeActivated = data.upgradeActivated;
        statsActivated = data.statsActivated;
        prestigeActivated = data.prestigeActivated;


        //achievements
        bestTrash = data.bestTrash;
        vacTimeAchivement = data.vacTimeAchivement;
        truckTimeAchivement = data.truckTimeAchivement;
        handTimeAchivement = data.handTimeAchivement;

        //prestige
        solarPanels = data.solarPanels;

        //skill 1
        vaccumTimeHold = data.vaccumTimeHold;
        vaccumTimeHoldCost = data.vaccumTimeHoldCost;
        vacCooldown = data.vacCooldown;
        vacCooldownHold = data.vacCooldownHold;
        vacCooldownCost = data.vacCooldownCost;
        hasVacSkill = data.hasVacSkill;

        //skill 2
        truckCooldown = data.truckCooldown;
        truckCooldownHold = data.truckCooldownHold;
        truckCooldownCost = data.truckCooldownCost;
        hasTruckSkill = data.hasTruckSkill;

        //skill 3
        handTimeHold = data.handTimeHold;
        handTimeHoldCost = data.handTimeHoldCost;
        handCooldown = data.handCooldown;
        handCooldownHold = data.handCooldownHold;
        handCooldownCost = data.handCooldownCost;
        hasHandSkill = data.hasHandSkill;

        //sounds
        MusicOnOff = data.MusicOnOff;
        sfxOnOff = data.sfxOnOff;

        //more trash
        moreTrash1 = data.moreTrash1;
        moreTrash2 = data.moreTrash2;
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

    private void Truck()
    {
        
        if (truckCooldown <= 0)
        {
            truckCooldown = 0;
        }
        else
        {
            truckCooldown -= Time.deltaTime;
        }

        
    }

    private void Hand()
    {
        handTime -= Time.deltaTime;
        if (handCooldown <= 0)
        {
            handCooldown = 0;
        }
        else
        {
            handCooldown -= Time.deltaTime;
        }

        if (handTime > 0)
        {
            handTimeAchivement += Time.deltaTime;
        }
    }
}
