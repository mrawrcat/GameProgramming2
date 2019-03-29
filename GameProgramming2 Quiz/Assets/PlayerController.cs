using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpforce;
    private float moveInput;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
      
            if(Input.GetKeyDown(KeyCode.W))
            {
                rb2d.velocity = Vector2.up * jumpforce;
                
            }
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        
        
    }
      
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "platform")
        {
            transform.parent = collision.transform;
            
            Debug.Log("on platform");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "platform")
        {
            transform.parent = null;
            Debug.Log("off platform");
        }
    }

    
}
