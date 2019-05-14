using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtons : MonoBehaviour
{
    public Button[] skillButton;
    public Button[] getSkillButton;
    public Text vacCooldown, vacDesc, bestVacTime;
    public Text truckCooldown, truckDesc, bestTruckTime;
    public Text handCooldown, handDesc, bestHandTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vacCooldown.text = Gamemanager.manager.vacCooldown.ToString("F0");
        bestVacTime.text = "Vaccum Time: " + Gamemanager.manager.vacTimeAchivement;
        truckCooldown.text = Gamemanager.manager.truckCooldown.ToString("F0");
        bestTruckTime.text = "Truck Time: " + Gamemanager.manager.truckTimeAchivement;
        handCooldown.text = Gamemanager.manager.handCooldown.ToString("F0");
        bestHandTime.text = "Hand Time: " + Gamemanager.manager.handTimeAchivement;
        VaccumSkill();
        TruckSkill();
        HandSkill();
    }

    public void getVaccumSkill()
    {
        if (Gamemanager.manager.trash >= 1000)
        {
            Gamemanager.manager.trash -= 1000;
            Gamemanager.manager.hasVacSkill = 1;
        }
    }

    public void getTruckSkill()
    {
        if (Gamemanager.manager.trash >= 10000)
        {
            Gamemanager.manager.trash -= 10000;
            Gamemanager.manager.hasTruckSkill = 1;
        }
    }

    public void getHandSkill()
    {
        if (Gamemanager.manager.trash >= 20000)
        {
            Gamemanager.manager.trash -= 20000;
            Gamemanager.manager.hasHandSkill = 1;
        }
    }

    public void plusTruckAchievement()
    {
        Gamemanager.manager.truckTimeAchivement++;
    }
    private void VaccumSkill()
    {
        //vaccumskill
        if (Gamemanager.manager.hasVacSkill == 0)
        {
            skillButton[0].interactable = false;
            vacCooldown.gameObject.SetActive(false);

        }
        if (Gamemanager.manager.trash < 1000)
        {
            getSkillButton[0].interactable = false;
        }
        if(Gamemanager.manager.trash >= 1000 && Gamemanager.manager.hasVacSkill == 0)
        {
            getSkillButton[0].interactable = true;
        }
        else
        {
            getSkillButton[0].interactable = false;
        }
       
        if (Gamemanager.manager.vacCooldown > 0)
        {
            skillButton[0].interactable = false;
            vacCooldown.gameObject.SetActive(true);
        }
        else
        {
            vacCooldown.gameObject.SetActive(false);
        }

        if (Gamemanager.manager.vacCooldown <= 0 && Gamemanager.manager.hasVacSkill == 1)
        {
            skillButton[0].interactable = true;
            //vacCooldown.gameObject.SetActive(false);
            vacDesc.gameObject.SetActive(true);
        }
    }

    private void TruckSkill()
    {
        
        if (Gamemanager.manager.hasTruckSkill == 0)
        {
            skillButton[1].interactable = false;
            truckCooldown.gameObject.SetActive(false);

        }
        if (Gamemanager.manager.trash < 10000)
        {
            getSkillButton[1].interactable = false;
        }
        if (Gamemanager.manager.trash >= 10000 && Gamemanager.manager.hasTruckSkill == 0)
        {
            getSkillButton[1].interactable = true;
        }
        else
        {
            getSkillButton[1].interactable = false;
        }

        if (Gamemanager.manager.truckCooldown > 0)
        {
            skillButton[1].interactable = false;
            truckCooldown.gameObject.SetActive(true);
        }

        if (Gamemanager.manager.truckCooldown <= 0 && Gamemanager.manager.hasTruckSkill == 1)
        {
            skillButton[1].interactable = true;
            truckCooldown.gameObject.SetActive(false);
            truckDesc.gameObject.SetActive(true);
        }
    }

    private void HandSkill()
    {
        
        if (Gamemanager.manager.hasHandSkill == 0)
        {
            skillButton[2].interactable = false;
            handCooldown.gameObject.SetActive(false);

        }
        if (Gamemanager.manager.trash < 20000)
        {
            getSkillButton[2].interactable = false;
        }
        if (Gamemanager.manager.trash >= 20000 && Gamemanager.manager.hasHandSkill == 0)
        {
            getSkillButton[2].interactable = true;
        }
        else
        {
            getSkillButton[2].interactable = false;
        }

        if (Gamemanager.manager.handCooldown > 0)
        {
            skillButton[2].interactable = false;
            handCooldown.gameObject.SetActive(true);
        }
        else
        {
            handCooldown.gameObject.SetActive(false);
        }

        if (Gamemanager.manager.handCooldown <= 0 && Gamemanager.manager.hasHandSkill == 1)
        {
            skillButton[2].interactable = true;
            //vacCooldown.gameObject.SetActive(false);
            handDesc.gameObject.SetActive(true);
        }
    }
}
