using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickTrash : MonoBehaviour
{
    public AudioSource clicksound;
    public Transform trashpos;
    private Helper helper;
    private HoverUIListener UIListener;
    // Start is called before the first frame update
    void Start()
    {
        UIListener = FindObjectOfType<HoverUIListener>();
        helper = FindObjectOfType<Helper>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Gamemanager.manager.slideval >= 30)
        {

            //Debug.Log("hit 30");
            Gamemanager.manager.goingdown = true;
            //Gamemanager.manager.slidevalvis -= Time.deltaTime;
            

        }
        if (Gamemanager.manager.slidevalvis <= 0)
        {
            Gamemanager.manager.slideval = 0;
            Gamemanager.manager.slidevalvis = 0;
            Gamemanager.manager.goingdown = false;

        }
        if (helper.currentparticle >= helper.reset)
        {
            helper.currentparticle = 0;
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
            Gamemanager.manager.trash += Gamemanager.manager.getTrash;
            helper.particles[helper.currentparticle].transform.position = trashpos.position;
            helper.particles[helper.currentparticle].SetActive(false);
            helper.particles[helper.currentparticle].SetActive(true);
            clicksound.Play();
            transform.position = new Vector2(Random.Range(-9,9), 30);
            helper.currentparticle++;
        
            if (Gamemanager.manager.slidevalvis >= 29 && Gamemanager.manager.goingdown == false)
            {
                Debug.Log("hit cap");
                Gamemanager.manager.trash += 30;
            }
            if (Gamemanager.manager.slideval <= 30 && Gamemanager.manager.goingdown == false)
            {
                Gamemanager.manager.slideval++;
                Gamemanager.manager.slidevalvis++;
            }
        }
    }
}
