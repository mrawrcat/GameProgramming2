using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movTruck : MonoBehaviour
{
    public float speed;
    public GameObject[] patrolPoints;
    public int whichPoint, passNum;
    public float distToPatrolPoint;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        render = GetComponent<SpriteRenderer>();
        passNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(passNum > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime * speed);
        }
       
        
        

        distToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[whichPoint].transform.position);

        if (distToPatrolPoint < 0.5f)
        {
            whichPoint++;
            passNum--;
            render.flipX = !render.flipX;
            if (whichPoint >= patrolPoints.Length)
            {
                whichPoint = 0;
            }
        }
    }

    public void moveTruck()
    {
        
        Gamemanager.manager.truckCooldown = Gamemanager.manager.truckCooldownHold;
        passNum = 3;

    }
}
