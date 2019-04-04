using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSwitch : MonoBehaviour
{
    public GameObject wall;
    //public string
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("stepped on switch");
            wall.GetComponent<MoveWall>().open = true;
            ///moveplatformscript.open = true;
        }
    }
}
