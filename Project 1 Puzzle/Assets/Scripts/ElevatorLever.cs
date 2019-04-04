using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLever : MonoBehaviour
{
    public GameObject wall;
    public string triggerObject;
    public Sprite[] sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == triggerObject && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("On Lever");
            wall.GetComponent<MoveWall>().open = !wall.GetComponent<MoveWall>().open;
            if (wall.GetComponent<MoveWall>().open == true)
            {
                GetComponent<SpriteRenderer>().sprite = sprite[1];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = sprite[0];
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == triggerObject && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("In Lever");
            wall.GetComponent<MoveWall>().open = !wall.GetComponent<MoveWall>().open;
            if (wall.GetComponent<MoveWall>().open == true)
            {
                GetComponent<SpriteRenderer>().sprite = sprite[1];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = sprite[0];
            }
        }
    }
    
}
