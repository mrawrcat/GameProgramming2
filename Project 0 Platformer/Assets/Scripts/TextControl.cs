using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    

    public Text timetext, crowntext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showtext();
    }

    void showtext()
    {
        timetext.text = "Time Remaining: " + Mathf.Round(GameManager.Gmgr.countdown);
        crowntext.text = "crowns collected: " + GameManager.Gmgr.crownNum + "/2";
    }
}
