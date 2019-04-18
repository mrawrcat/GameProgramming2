using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReseGameDoor : MonoBehaviour
{
    private GameHelper gHelper;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gHelper = FindObjectOfType<GameHelper>();
            gHelper.Restart();
        }
    }
}
