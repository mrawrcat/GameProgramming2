﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameManager.Gmgr.Countdown();
    }
    public void callGmgrSceneSwitch(string scene)
    {
        GameManager.Gmgr.scneSwitch(scene);
    }
}
