using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movHand : MonoBehaviour
{
    
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamemanager.manager.handTime <= 0)
        {
            hand.transform.position = new Vector2(65, 65);
        }
    }

    public void moveHand()
    {
        hand.transform.position = new Vector2(0, 0);
        Gamemanager.manager.handTime = Gamemanager.manager.handTimeHold;
        Gamemanager.manager.handCooldown = Gamemanager.manager.handCooldownHold;

    }
}
