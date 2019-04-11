using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasKeyOpenGate : MonoBehaviour
{
    public GameObject wall;
    //public string triggerObject;
    private PlayerPlusGhost player;
    private UsedKey usedkey;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerPlusGhost>();
        usedkey = FindObjectOfType<UsedKey>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.collider.tag == "Player" && player.gotKey == true)
      {
            wall.GetComponent<MoveWall>().open = true;
            player.gotKey = false;
            player.usedKey = true;
            usedkey.usethekey();
      }  
    }
}
