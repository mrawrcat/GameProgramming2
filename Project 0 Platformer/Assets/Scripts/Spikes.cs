using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private ShowPanels showPanel;
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            showPanel = FindObjectOfType<ShowPanels>();
            showPanel.showGameOverPanel();
        }
    }
}
