﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    public Transform playerhead;
    private bool gotcrown;
    private float originalY;
    public float floatStrength;
    // Start is called before the first frame update
    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Gmgr.gotCrown == true)
        {
            Debug.Log("crown got");
            Vector2 target = playerhead.position;
            transform.position = Vector2.MoveTowards(transform.position, target, 2 * Time.deltaTime);
        }
        else if(GameManager.Gmgr.gotCrown == false)
        {
            transform.position = new Vector3(transform.position.x,
            originalY + (Mathf.Sin(Time.time) * floatStrength),
            transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && GameManager.Gmgr.gotCrown == false)
        {

            Debug.Log("Crown Obtained");
            if (!PlayerPrefs.HasKey(GameManager.Gmgr.scene.name))
            {
                GameManager.Gmgr.crownNum++;

            }
            
            Debug.Log(GameManager.Gmgr.crownNum);
            GameManager.Gmgr.gotCrown = true;
            //gameObject.SetActive(false);
            //Vector2 target = playerhead.position;
            //transform.position = Vector2.MoveTowards(transform.position, target, 1 * Time.deltaTime);
        }
    }

    
}
