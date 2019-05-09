using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public GameObject[] patrolPoints;
    int whichPoint;
    float distToPatrolPoint;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime * speed);

        distToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[whichPoint].transform.position);

        if (distToPatrolPoint < 0.02f)
        {
            whichPoint++;
            render.flipX = !render.flipX;
            if (whichPoint >= patrolPoints.Length)
            {
                whichPoint = 0;
            }
        }
    }
}
