using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffectorLever : MonoBehaviour
{
    public GameObject wall;
    public string triggerObject;
    public Sprite[] sprite;
    private float prevMag;
    
    
    // Start is called before the first frame update
    void Start()
    {
        prevMag = wall.GetComponent<AreaEffector2D>().forceMagnitude;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == triggerObject && Input.GetKeyDown(KeyCode.Space))
        {
           
            Debug.Log("Used Lever");
            if(wall.GetComponent<AreaEffector2D>().forceMagnitude == prevMag)
            {
                wall.GetComponent<AreaEffector2D>().forceMagnitude = 0;
            }
            else if(wall.GetComponent<AreaEffector2D>().forceMagnitude == 0)
            {
                wall.GetComponent<AreaEffector2D>().forceMagnitude = prevMag;
            }
        }
    }
}
