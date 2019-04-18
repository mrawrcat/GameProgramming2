using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlFinishDoor : MonoBehaviour
{
    public Transform completeTeleport;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.GetComponent<PlayerPlusGhost>().bodyControl == true)
            {
                collision.transform.position = completeTeleport.transform.position;
            }
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerPlusGhost>().bodyControl == true)
            {
                collision.transform.position = completeTeleport.transform.position;
            }

        }
    }
}
