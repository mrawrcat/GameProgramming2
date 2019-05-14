using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoreData
{

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
    
    //tutorial
    public int helloWelcome, clickOnTrash, thisIsUpgrade, firstUpgrade, thisIsShop, firstHire;
    public int statsTut, prestigeTut;
    public int shopActivated, upgradeActivated;
    //special skill 1
    public float vaccumTime, vaccumTimeHold, vaccumTimeHoldCost, vacCooldown, vacCooldownHold, vacCooldownCost, hasVacSkill;
    //special skill 2
    public float truckCooldown, truckCooldownHold, truckCooldownCost, hasTruckSkill;
    //special skill 3
    public float handTime, handTimeHold, handTimeHoldCost, handCooldown, handCooldownHold, handCooldownCost, hasHandSkill;
    //Stats/Achievements
    public float bestTrash;
    public float vacTimeAchivement, truckTimeAchivement, handTimeAchivement;
    //Prestige mechanics
    public float solarPanels;
    //more trash
    public float moreTrash1, moreTrash2;

    //music
    public float MusicOnOff, sfxOnOff;
    public StoreData(Gamemanager manager)
    {
        trash = manager.trash;
        trashpersec = manager.trashpersec;
        getTrash = manager.getTrash;
        getTrashCost = manager.getTrashCost;

        //shop -> amt of each type of shop
        friend = manager.friend;
        garbageman = manager.garbageman;
        organization = manager.organization;
        government = manager.government;
        cult = manager.cult;


        friendcost = manager.friendcost;
        garbagemancost = manager.garbagemancost;
        orgcost = manager.orgcost;
        govcost = manager.govcost;
        cultcost = manager.cultcost;

        org_bw = manager.org_bw;
        gov_bw = manager.gov_bw;
        cult_bw = manager.cult_bw;

        //tutorial
        helloWelcome = manager.helloWelcome;
        clickOnTrash = manager.clickOnTrash;
        thisIsShop = manager.thisIsShop;
        firstHire = manager.firstHire;
        thisIsUpgrade = manager.thisIsUpgrade;
        firstUpgrade = manager.firstUpgrade;
        statsTut = manager.statsTut;
        prestigeTut = manager.prestigeTut;
        shopActivated = manager.shopActivated;
        upgradeActivated = manager.upgradeActivated;

        //achievements
        bestTrash = manager.bestTrash;
        vacTimeAchivement = manager.vacTimeAchivement;
        truckTimeAchivement = manager.truckTimeAchivement;
        handTimeAchivement = manager.handTimeAchivement;

        //prestige
        solarPanels = manager.solarPanels;

        //skill 1
        vaccumTimeHold = manager.vaccumTimeHold;
        vaccumTimeHoldCost = manager.vaccumTimeHoldCost;
        vacCooldown = manager.vacCooldown;
        vacCooldownHold = manager.vacCooldownHold;
        vacCooldownCost = manager.vacCooldownCost;
        hasVacSkill = manager.hasVacSkill;

        //skill 2
        
        truckCooldown = manager.truckCooldown;
        truckCooldownHold = manager.truckCooldownHold;
        truckCooldownCost = manager.truckCooldownCost;
        hasTruckSkill = manager.hasTruckSkill;

        //skill 3
        handTimeHold = manager.handTimeHold;
        handTimeHoldCost = manager.handTimeHoldCost;
        handCooldown = manager.handCooldown;
        handCooldownHold = manager.handCooldownHold;
        handCooldownCost = manager.handCooldownCost;
        hasHandSkill = manager.hasHandSkill;

        MusicOnOff = manager.MusicOnOff;
        sfxOnOff = manager.sfxOnOff;

        //more trash
        moreTrash1 = manager.moreTrash1;
        moreTrash2 = manager.moreTrash2;
    }
}
