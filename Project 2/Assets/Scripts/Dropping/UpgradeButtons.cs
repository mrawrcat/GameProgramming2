using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
    public Button[] upgradeButton;
    public Text trashSkill, vaccumTxt;
    public Text trashSkillCost, vaccumTxtCost;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.manager.trash >= Gamemanager.manager.getTrashCost)
        {
            upgradeButton[0].interactable = true;
        }
        else
        {
            upgradeButton[0].interactable = false;
        }
    }
}
