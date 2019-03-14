using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public Transform bRespawn;
    private PlayerController playerControl;
    private ShowPanels showPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
