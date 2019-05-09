using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVac : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Gamemanager.manager.vaccumTime <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].transform.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].transform.position, Time.deltaTime * speed);
        }
    }
    

    public void moveVaccum()
    {
       Gamemanager.manager.vaccumTime = Gamemanager.manager.vaccumTimeHold;
       Gamemanager.manager.vacCooldown = Gamemanager.manager.vacCooldownHold;
       
    }
}
