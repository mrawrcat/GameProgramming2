using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
    public Button[] upgradeButton;
    

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
