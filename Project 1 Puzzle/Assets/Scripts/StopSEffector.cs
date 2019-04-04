using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSEffector : MonoBehaviour
{
    public GameObject conveyor;
    public Animator[] anims;

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
        if (collision.CompareTag("Ghost"))
        {
            conveyor.GetComponent<SurfaceEffector2D>().speed = 0;
            conveyor.layer = 8;
            for(int i = 0; i < anims.Length; i++)
            {
                anims[i].enabled = false;
            }
        }
    }
}
