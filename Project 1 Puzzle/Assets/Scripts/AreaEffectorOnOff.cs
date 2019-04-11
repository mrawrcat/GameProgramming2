using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffectorOnOff : MonoBehaviour
{
    public GameObject wall;
    public string triggerObject;
    public Sprite[] sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == triggerObject)
        {
            wall.GetComponent<AreaEffector2D>().forceMagnitude = 0;
            wall.GetComponent<SpriteRenderer>().color = Color.gray;
            GetComponent<SpriteRenderer>().sprite = sprite[1];

            
        }
    }
}
