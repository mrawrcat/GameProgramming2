using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject[] Vcams;
    public GameObject[] coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchCams(int cams)
    {
        Vcams[cams].SetActive(true);
        Vcams[cams+1].SetActive(false);
        Vcams[cams-1].SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
        }
    }
}
