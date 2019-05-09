using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccum : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Trash")
        {
            collision.transform.position = new Vector2(Random.Range(-9, 9), 30);
            Gamemanager.manager.trash += Gamemanager.manager.getTrash;
        }
    }
}
