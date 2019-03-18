using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpforce, checkradius;
    public Transform groundcheck;
    public LayerMask whatIsGround;
    public bool canControl, isjump, canJump;
    //public GameObject holdcrate;
    private float moveInput;
    private bool faceR = true, isGrounded = true;
    private Rigidbody2D rb2d;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        canControl = true;
        isjump = false;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl && canJump)
        {
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb2d.velocity = Vector2.up * jumpforce;
                
            }
            if (!isGrounded)
            {
                anim.SetBool("isJumping", true);
            }
            else
            {
                anim.SetBool("isJumping", false);
            }
        }
        
    }
    void FixedUpdate()
    {
        
        if (canControl)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatIsGround);
            RunControl();
            
            if(moveInput != 0)
            {
                anim.SetBool("isMoving", true);
            
            }else if(moveInput == 0)
            {
                anim.SetBool("isMoving", false);
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        
    }

    void Flip()
    {
        faceR = !faceR;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        
        

    }
    void RunControl()
    {
        if(faceR && moveInput < 0)
        {
            Flip();
            

        }
        else if(!faceR && moveInput > 0)
        {
            Flip();
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "moving platform")
        {
            transform.parent = collision.transform;
            Debug.Log("on platform");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "moving platform")
        {
            transform.parent = null;
            Debug.Log("off platform");
        }
    }

    
}
