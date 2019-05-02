using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainPlastic : MonoBehaviour
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
            //GameManager.gmanager.bonusMulti = 1;
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
            if (GameManager.gmanager.plastic < GameManager.gmanager.plasticCap)
            {
                GameManager.gmanager.plastic += 1;

                if (GameManager.gmanager.bonusVisual >= 29)
                {
                    GameManager.gmanager.plastic += 50;
                    GameManager.gmanager.bonusMulti = 2;
                    Debug.Log("plus 50 plastic, increased production?");

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
