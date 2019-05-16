using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
    public Button[] upgradeButton;
    public Text skill1, skill2, skill3, gotTrash1, gotTrash2;

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
        moreTrash();

        if(Gamemanager.manager.moreTrash1 == 1)
        {
            gotTrash1.text = "GOT!";
        }
        else
        {
            gotTrash1.text = "Cost: 5000 Trash";
        }

        if (Gamemanager.manager.moreTrash2 == 1)
        {
            gotTrash2.text = "GOT!";
        }
        else
        {
            gotTrash2.text = "Cost: 15000 Trash";
        }

        if(Gamemanager.manager.hasVacSkill == 1)
        {
            skill1.text = "GOT!";
        }
        else
        {
            skill1.text = "Cost: 1000 Trash";
        }

        if (Gamemanager.manager.hasTruckSkill == 1)
        {
            skill2.text = "GOT!";
        }
        else
        {
            skill2.text = "Cost: 10000 Trash";
        }
        if (Gamemanager.manager.hasHandSkill == 1)
        {
            skill3.text = "GOT!";
        }
        else
        {
            skill3.text = "Cost: 20000 Trash";
        }

    }

    private void moreTrash()
    {
        if(Gamemanager.manager.trash >= 5000 && Gamemanager.manager.moreTrash1 == 0)
        {
            upgradeButton[1].interactable = true;
        }
        else
        {
            upgradeButton[1].interactable = false;
        }

        if (Gamemanager.manager.trash >= 15000 && Gamemanager.manager.moreTrash2 == 0)
        {
            upgradeButton[2].interactable = true;
        }
        else
        {
            upgradeButton[2].interactable = false;
        }
    }

    public void getMoreTrash1()
    {
        Gamemanager.manager.moreTrash1 = 1;
    }

    public void getMoreTrash2()
    {
        Gamemanager.manager.moreTrash2 = 1;
    }
}
