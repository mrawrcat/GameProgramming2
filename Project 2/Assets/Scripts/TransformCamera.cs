using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformCamera : MonoBehaviour
{
    public Transform[] tab;
    public int currentTab;
    public Button leftButton, rightButton;
    public bool unlocked;
    private void Start()
    {
        currentTab = 0;
        unlocked = false;
    }
    private void Update()
    {
        if(currentTab == 0)
        {
            leftButton.gameObject.SetActive(false);
            
        }
        else
        {
            leftButton.gameObject.SetActive(true);
        }
        if(currentTab == tab.Length - 1)
        {
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            if(unlocked == true)
            {
                rightButton.gameObject.SetActive(true);
            }
           
        }

    }
    public void toTab()
    {
        Camera.main.transform.position = new Vector3(tab[0].position.x, tab[0].position.y, -10);

    }
    public void toTab1()
    {
        Camera.main.transform.position = new Vector3(tab[1].position.x, tab[1].position.y, -10);

    }
    public void toTab2()
    {
        Camera.main.transform.position = new Vector3(tab[2].position.x, tab[2].position.y, -10);

    }
    public void toRight()
    {
        if(currentTab < tab.Length-1)
        {
            currentTab++;
            Camera.main.transform.position = new Vector3(tab[currentTab].position.x, tab[0].position.y, -10);

        }
        
    }
    public void toLeft()
    {
        if (currentTab > 0)
        {
            currentTab--;
            Camera.main.transform.position = new Vector3(tab[currentTab].position.x, tab[0].position.y, -10);
        }
    }

}
