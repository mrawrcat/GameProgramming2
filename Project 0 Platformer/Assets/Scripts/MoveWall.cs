using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public GameObject platform;
    public float movespeed;
    public Transform currentpoint;
    public Transform[] points;
    public int pointselection;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        currentpoint = points[pointselection];
    }

    // Update is called once per frame
    void Update()
    {
        movewall();
    }

    void movewall()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentpoint.position, movespeed * Time.deltaTime);
        if(open)
        {
            pointselection = 1;
            currentpoint = points[pointselection];
        }
        if(!open)
        {
            pointselection = 0;
            currentpoint = points[pointselection];
        }
    }
}
