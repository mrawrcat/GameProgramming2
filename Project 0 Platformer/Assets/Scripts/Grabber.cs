using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {
    public bool grabbed;
    RaycastHit2D hitright, hitleft, choosehit;
    public float distance = 2f;
    public Transform holdpoint, holdpoint2;
    public float throwforce;
    public LayerMask notgrabbed;
    public Player playerscript;
    
    
    // Use this for initialization
    void Start () {
        playerscript = GetComponent<Player>();
	}

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;
                if (playerscript.mySpriteRenderer.flipX == false)
                {
                    hitright = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance);
                }
                else
                {
                    hitright = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                }
                

                if (hitright.collider != null && hitright.collider.tag == "Grabable")
                {
                    grabbed = true;
                    
                }


                //grab
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;

                if (hitright.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    if (playerscript.mySpriteRenderer.flipX == false)
                    {
                        hitright.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-transform.localScale.x, 1) * throwforce;
                    }
                    else
                    {
                        hitright.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                    }
                    
                }


                //throw
            }


        }

        if (grabbed)
        {
            if (playerscript.mySpriteRenderer.flipX == false)
            {
                hitright.collider.gameObject.transform.position = holdpoint2.position;
            }
            else
            {
                hitright.collider.gameObject.transform.position = holdpoint.position;
            }
            
        }
           


    }
    void choosehitrightleft()
    {
        if(playerscript.mySpriteRenderer.flipX == false)
        {
            choosehit = hitleft;
        }
        else
        {
            choosehit = hitright;
        }
    }
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;

    //    Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    //}
    public void grabObject()
    {
        if (!grabbed)
        {
            Physics2D.queriesStartInColliders = false;
            if (playerscript.mySpriteRenderer.flipX == false)
            {
                hitright = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance);
            }
            else
            {
                hitright = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
            }


            if (hitright.collider != null && hitright.collider.tag == "Grabable")
            {
                grabbed = true;

            }


            //grab
        }
        else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
        {
            grabbed = false;

            if (hitright.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                if (playerscript.mySpriteRenderer.flipX == false)
                {
                    hitright.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-transform.localScale.x, 1) * throwforce;
                }
                else
                {
                    hitright.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                }

            }


            //throw
        }

    }
}