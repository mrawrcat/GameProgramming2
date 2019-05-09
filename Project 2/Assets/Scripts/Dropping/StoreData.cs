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
    public float friend, garbageman;
    //cost to get the type of building
    public float friendcost, garbagemancost;
    //cost of next getTrash;
    public float getTrashCost;
    public float slideval, slidevalvis;
    public bool goingdown;
    public bool tutState;
    public int tutorialState;
    //special skills
    public float vaccumTime, vaccumTimeHold, vaccumTimeHoldCost, vacCooldown, vacCooldownHold, vacCooldownCost, hasVacSkill;
    //Stats/Achievements
    public float bestTrash;
    public float vacTimeAchivement;
    //Prestige mechanics
    public float solarPanels;

    //music
    public float MusicOnOff;
    public StoreData(Gamemanager manager)
    {
        trash = manager.trash;
        trashpersec = manager.trashpersec;
        getTrash = manager.getTrash;
        getTrashCost = manager.getTrashCost;
        friend = manager.friend;
        friendcost = manager.friendcost;
        //slideval = manager.slideval;
        //slidevalvis = manager.slidevalvis;
        tutorialState = manager.tutorialState;
        bestTrash = manager.bestTrash;
        solarPanels = manager.solarPanels;
        vaccumTimeHold = manager.vaccumTimeHold;
        vaccumTimeHoldCost = manager.vaccumTimeHoldCost;
        vacCooldown = manager.vacCooldown;
        vacCooldownHold = manager.vacCooldownHold;
        vacCooldownCost = manager.vacCooldownCost;
        hasVacSkill = manager.hasVacSkill;
        vacTimeAchivement = manager.vacTimeAchivement;
        MusicOnOff = manager.MusicOnOff;
    }
}
