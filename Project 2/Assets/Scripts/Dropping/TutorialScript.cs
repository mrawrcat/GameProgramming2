using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject[] TutorialObj;
   
    // Start is called before the first frame update
    void Start()
    {
        if(Gamemanager.manager.clickOnTrash == 0)
        {
            TutorialObj[2].SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamemanager.manager.helloWelcome == 1)
        {
            TutorialObj[1].SetActive(true);
        }
        else
        {
            TutorialObj[1].SetActive(false);
        }
        if(Gamemanager.manager.clickOnTrash == 1)
        {
            TutorialObj[2].SetActive(true);
        }
        else
        {
            TutorialObj[2].SetActive(false);
        }

        if(Gamemanager.manager.thisIsUpgrade == 1)
        {
            TutorialObj[5].SetActive(true);
        }
        else
        {
            TutorialObj[5].SetActive(false);
        }

        if(Gamemanager.manager.firstUpgrade == 1)
        {
            TutorialObj[6].SetActive(true);
        }
        else
        {
            TutorialObj[6].SetActive(false);
        }

        if(Gamemanager.manager.thisIsShop == 1)
        {
            TutorialObj[3].SetActive(true);
        }
        else
        {
            TutorialObj[3].SetActive(false);
        }

        if(Gamemanager.manager.firstHire == 1)
        {
            TutorialObj[4].SetActive(true);
        }
        else
        {
            TutorialObj[4].SetActive(false);
        }

        if(Gamemanager.manager.statsTut == 1)
        {
            TutorialObj[8].SetActive(true);
        }
        else
        {
            TutorialObj[8].SetActive(false);
        }

        if (Gamemanager.manager.prestigeTut == 1)
        {
            TutorialObj[7].SetActive(true);
        }
        else
        {
            TutorialObj[7].SetActive(false);
        }

        
    }
    public void helloToClickTrash()
    {
        TutorialObj[1].SetActive(false);
        Gamemanager.manager.helloWelcome = 0;
        Gamemanager.manager.clickOnTrash = 1;
    }
    public void gotFirstMorePickup()
    {
        Gamemanager.manager.upgradeWasActive = true;
        Gamemanager.manager.firstUpgrade = 0;
        Gamemanager.manager.upgradeActivated = 1;
    }
    public void hireFirstTPS()
    {
        Gamemanager.manager.thisIsShopWasActive = true;
        Gamemanager.manager.firstHire = 0;
        Gamemanager.manager.shopActivated = 1;
    }
    public void closeThisIsShop()
    {
        Gamemanager.manager.thisIsShop = 0;
        
    }
    public void closeThisIsUpgrade()
    {
        Gamemanager.manager.thisIsUpgrade = 0;

    }
    public void closePrestigeTut()
    {
        
        Gamemanager.manager.prestigeTut = 0;
    }
    public void closeStatsTut()
    {
       
        Gamemanager.manager.statsTut = 0;
    }
    public void TutorialOn()
    {
        Gamemanager.manager.helloWelcome = 1;
        Gamemanager.manager.activateThisIsShop = false;
        Gamemanager.manager.thisIsShopWasActive = false;
        Gamemanager.manager.activateUpgrade = false;
        Gamemanager.manager.upgradeWasActive = false;
        Gamemanager.manager.upgradeActivated = 0;
        Gamemanager.manager.shopActivated = 0;
        Gamemanager.manager.firstHire = 1;
        Gamemanager.manager.firstUpgrade = 1;
        Gamemanager.manager.statsTut = 1;
        Gamemanager.manager.prestigeTut = 1;
    }
    public void TutorialOff()
    {

        
    }
}
