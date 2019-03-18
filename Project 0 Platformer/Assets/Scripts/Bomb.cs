using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public Transform bRespawn;
    private PlayerController playerControl;
    private ShowPanels showPanel;
    private Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        showPanel = FindObjectOfType<ShowPanels>();

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Gmgr.countdown < 20 || GameManager.Gmgr.bomblife < 2)
        {
            anim.SetBool("bomblink", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            showPanel = FindObjectOfType<ShowPanels>();
            Debug.Log(showPanel.name);
            showPanel.showCompletePanel();
            playerControl.canControl = false;
            if(GameManager.Gmgr.gotCrown == true)
            { 
                    PlayerPrefs.SetInt(GameManager.Gmgr.scene.name, 1);
                    PlayerPrefs.SetInt("crownNum", GameManager.Gmgr.crownNum);
            }
        }
        if (other.CompareTag("spikes"))
        {
            Debug.Log("out of bounds");
            transform.position = bRespawn.position;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("savebomb"))
        {
            Debug.Log("out of bounds");
            transform.position = bRespawn.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground" && GameManager.Gmgr.bomblife < 1)
        {
            //showPanel = FindObjectOfType<ShowPanels>();
            showPanel.showGameOverPanel();
        }
    }
}
