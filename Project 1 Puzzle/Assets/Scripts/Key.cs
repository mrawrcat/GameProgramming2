using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Transform playerhead;
    public bool gotkey;
    private float originalY;
    public float floatspeed;
    //public float floatStrength;
    private PlayerPlusGhost player;
    // Start is called before the first frame update
    void Start()
    {
        originalY = transform.position.y;
        gotkey = false;
        player = FindObjectOfType<PlayerPlusGhost>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gotkey == true)
        {
            Vector2 target = playerhead.position;
            transform.position = Vector2.MoveTowards(transform.position, target, floatspeed * Time.deltaTime);
            transform.parent = playerhead.transform;
        }
        if(player.usedKey == true)
        {
            //player.usedKey = false;
            //this.gameObject.SetActive(false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ghost" && player.gotKey == false)
        {
            gotkey = true;
            player.gotKey = true;
        }
        if (collision.tag == "Player" && player.gotKey == false)
        {
            gotkey = true;
            player.gotKey = true;
        }
    }
}
