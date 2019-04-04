using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{
    //private MoveWall moveplatformscript;
    public GameObject wall;
    public string triggerObject;
    // Start is called before the first frame update
    void Start()
    {
        //moveplatformscript = FindObjectOfType<MoveWall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == triggerObject)
        {
            Debug.Log("stepped on switch");
            wall.GetComponent<MoveWall>().open = true;
            ///moveplatformscript.open = true;
        }
    }

}
