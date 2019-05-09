using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainMetal : MonoBehaviour
{
    private HoverUIListener UIListener;
    public bool goingdown;
    private void Start()
    {
        UIListener = FindObjectOfType<HoverUIListener>();
        goingdown = false;
    }
    private void Update()
    {
        if (GameManager.gmanager.bonusCount >= 30)
        {
            
            //Debug.Log("hit 30");
            GameManager.gmanager.bonusVisual -= Time.deltaTime;
            goingdown = true;

        }
        if (GameManager.gmanager.bonusVisual <= 0)
        {
            GameManager.gmanager.bonusCount = 0;
            GameManager.gmanager.bonusVisual = 0;
            GameManager.gmanager.bonusMulti = 1;
            goingdown = false;

        }
    }
    private void OnMouseDown()
    {
        if (UIListener.isUIOverride)
        {
            Debug.Log("Cancelled OnMouseDown! A UI element has override this object!");
        }
        else
        {
            if (GameManager.gmanager.aluminum < GameManager.gmanager.aluminumCap)
            {
                GameManager.gmanager.aluminum += 1;

                if (GameManager.gmanager.bonusVisual >= 29)
                {
                    if (GameManager.gmanager.aluminum <= GameManager.gmanager.aluminumCap - 50)
                    {
                        GameManager.gmanager.aluminum += 50;
                        GameManager.gmanager.bonusMulti = 2;
                        Debug.Log("plus 50 trash, increased production?");
                    }
                    else if (GameManager.gmanager.aluminum > GameManager.gmanager.aluminumCap - 50)
                    {
                        GameManager.gmanager.aluminum = GameManager.gmanager.aluminumCap;
                    }

                }

            }
            if (GameManager.gmanager.bonusCount <= 30 && goingdown == false)
            {
                GameManager.gmanager.bonusCount++;
                GameManager.gmanager.bonusVisual++;
            }

        }

    }
}
