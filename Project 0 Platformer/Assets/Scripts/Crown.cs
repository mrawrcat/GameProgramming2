﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            Debug.Log("Crown Obtained");
            if (!PlayerPrefs.HasKey(GameManager.Gmgr.scene.name))
            {
                GameManager.Gmgr.crownNum++;

            }
            
            Debug.Log(GameManager.Gmgr.crownNum);
            GameManager.Gmgr.gotCrown = true;
            gameObject.SetActive(false);
        }
    }
}
