using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCam : MonoBehaviour
{
    public int camState;
    public GameObject[] Vcams;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            foreach(GameObject cam in Vcams)
            {
                cam.SetActive(false);
            }
            Vcams[camState].SetActive(true);
        }
        
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (GameObject cam in Vcams)
            {
                cam.SetActive(false);
            }
            Vcams[camState].SetActive(true);
        }

    }
}
