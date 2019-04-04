using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabscript : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if ((hit.collider != null && hit.collider.tag == "bomb") || (hit.collider != null && hit.collider.tag == "Crate"))
                {
                    grabbed = true;

                }


                //grab
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null && hit.collider.tag == "bomb")
                {
                    //throws in direction of x localscale(direction facing) and y localscale
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                    //GameManager.Gmgr.bomblife--;
                }
                else if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null && hit.collider.tag == "Crate")
                {
                    //throws in direction of x localscale(direction facing) and y localscale
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0) * 1;
                    //GetComponent<PlayerController>().canJump = true;
                   

                }



                //throw
            }


        }

        //put object in a transform position
        if (grabbed)
            if(hit.collider.tag == "bomb")
            {
                hit.collider.gameObject.transform.position = holdpoint.position;
            }
            else if (hit.collider.tag == "Crate")
            {
                
                //GetComponent<PlayerController>().canJump = false;
                hit.collider.gameObject.transform.position = holdpoint.position;
                //hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(rb2d.velocity.x, 0);
            }


    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
