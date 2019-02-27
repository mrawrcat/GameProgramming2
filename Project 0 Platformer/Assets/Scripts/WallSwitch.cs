using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : MonoBehaviour
{
    private MoveWall moveplatformscript;
    
    // Start is called before the first frame update
    void Start()
    {
        moveplatformscript = FindObjectOfType<MoveWall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "crate")
        {
            Debug.Log("stepped on switch");
            moveplatformscript.open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "crate")
        {
            Debug.Log("stepped off switch");
            moveplatformscript.open = false;
        }
    }
}
