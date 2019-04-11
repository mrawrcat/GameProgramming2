using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLedge : MonoBehaviour
{
    //private PlayerPlusGhost player;
    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<PlayerPlusGhost>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ledge")
        {
            if (gameObject.GetComponentInParent<PlayerPlusGhost>().bodyControl == true)
            {
                gameObject.GetComponentInParent<PlayerPlusGhost>().startClimbLedge();
            }
           
        }
    }
}
