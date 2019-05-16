using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject[] TutorialObj;
    private bool mainTutDone;
    // Start is called before the first frame update
    void Start()
    {
        if (Gamemanager.manager.helloWelcome == 1)
        {
            TutorialObj[0].SetActive(true);
        }
        else
        {
            TutorialObj[0].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.manager.helloWelcome == 1)
        {
            TutorialObj[0].SetActive(true);
        }
        else
        {
            TutorialObj[0].SetActive(false);
        }

        if(Gamemanager.manager.trash >= 10 && Gamemanager.manager.thisIsUpgrade == 0 && mainTutDone == true)
        {
            
            TutorialObj[5].SetActive(true);
        }

        if (Gamemanager.manager.trash >= 15 && Gamemanager.manager.thisIsShop == 0 && Gamemanager.manager.upgradeActivated == 1)
        {
            TutorialObj[7].SetActive(true);
        }

        if (Gamemanager.manager.trash >= 100 && Gamemanager.manager.shopActivated == 1 && Gamemanager.manager.statsTut == 0)
        {
            TutorialObj[9].SetActive(true);
        }

        if (Gamemanager.manager.trash >= 100 && Gamemanager.manager.statsActivated == 1 && Gamemanager.manager.prestigeTut == 0)
        {
            TutorialObj[11].SetActive(true);
        }

    }

    public void helloToClickTrash()
    {
        
        Gamemanager.manager.helloWelcome = 0;
        
    }
    public void closeThisIsShop()
    {
        TutorialObj[7].SetActive(false);
        if (Gamemanager.manager.thisIsShop == 0)
        {
            TutorialObj[8].SetActive(true);
        }
        Gamemanager.manager.thisIsShop = 1;
        
    }
    public void turnShopOn()
    {
        if (Gamemanager.manager.thisIsShop == 1)
        {
            Gamemanager.manager.shopActivated = 1;
        }
    }
    public void closeThisIsUpgrade()
    {
        TutorialObj[5].SetActive(false);
        if (Gamemanager.manager.thisIsUpgrade == 0)
        {
            TutorialObj[6].SetActive(true);
        }
        Gamemanager.manager.thisIsUpgrade = 1;

    }
    public void turnHireOn()
    {
        if (Gamemanager.manager.thisIsUpgrade == 1)
        {
            Gamemanager.manager.upgradeActivated = 1;
        }
        
    }
    public void closeStats()
    {
        TutorialObj[9].SetActive(false);
        if (Gamemanager.manager.statsTut == 0)
        {
            TutorialObj[10].SetActive(true);
        }
            
        Gamemanager.manager.statsTut = 1;
    }
    public void turnStatsOn()
    {
        if(Gamemanager.manager.statsTut == 1)
        {
            Gamemanager.manager.statsActivated = 1;
        }
    }
    public void closePrestige()
    {
        TutorialObj[11].SetActive(false);
        if(Gamemanager.manager.prestigeTut == 0)
        {
            TutorialObj[12].SetActive(true);
        }
        
        Gamemanager.manager.prestigeTut = 1;
    }
    public void turnPrestigeOn()
    {
        if (Gamemanager.manager.prestigeTut == 1)
        {
            Gamemanager.manager.prestigeActivated = 1;
        }
    }
    public void TutorialOn()
    {
        Gamemanager.manager.helloWelcome = 1;
        Gamemanager.manager.thisIsUpgrade = 0;
        Gamemanager.manager.thisIsShop = 0;
        Gamemanager.manager.statsTut = 0;
        Gamemanager.manager.prestigeTut = 0;

        Gamemanager.manager.upgradeActivated = 0;
        Gamemanager.manager.shopActivated = 0;

        Gamemanager.manager.statsActivated = 0;
        Gamemanager.manager.prestigeActivated = 0;
        mainTutDone = false;

    }
    public void finishMainTut()
    {
        mainTutDone = true;
        
    }
}
