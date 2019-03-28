using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed, jumpforce, checkradius;
    public Transform groundcheck;
    public LayerMask whatIsGround;
    public bool bodyControl, isjump, canJump, ghosted;
    private float moveInputX, moveInputY;
    public bool faceR = true, isGrounded = true, rGravity;
    private Rigidbody2D rb2d;
    private Animator anim;
    private GhostController ghostcontrol;
    public GameObject shackle;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        bodyControl = true;
        ghosted = false;
        isjump = false;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyControl)
        {
            if(Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb2d.velocity = Vector2.up * jumpforce;
                
            }
            if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
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
        if (Input.GetKeyDown(KeyCode.E))
        { 
            bodyControl = !bodyControl;
            ghosted = !ghosted;
            if(ghosted == false)
            {
                transform.position = shackle.transform.position;
            }
            
        }
        if(ghosted == true)
        {
           anim.SetBool("isGhost", true);
            shackle.SetActive(true);
            
        }
        if(ghosted == false)
        {
            //transform.position = shackle.transform.position;
           anim.SetBool("isGhost", false);
           shackle.transform.position = transform.position;
           shackle.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            upsideDown();
        }
        
       
        
    }
    void FixedUpdate()
    {
        
        if (bodyControl)
        {
            //rb2d.gravityScale = 1;
            //moveInput = Input.GetAxis("Horizontal");
            //rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
            moveInputX = Input.GetAxis("Horizontal");
            moveInputY = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector2(moveInputX * speed, rb2d.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatIsGround);
            Facing();
            if (moveInputX != 0 && isGrounded)
            {
                anim.SetBool("isRunning", true);

            }
            else if (moveInputX == 0 && isGrounded)
            {
                anim.SetBool("isRunning", false);
            }

        }
        else if (ghosted)
        {
            moveInputX = Input.GetAxis("Horizontal");
            moveInputY = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector2(moveInputX * speed, moveInputY * speed);
            Facing();
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
    void Facing()
    {
        if(faceR && moveInputX < 0)
        {
            Flip();
        }
        else if(!faceR && moveInputX > 0)
        {
            Flip();
        }
    }
    void ghostControl()
    {
        if (ghosted)
        {
            rb2d.gravityScale = 0;
            rb2d.velocity = new Vector2(0, 0);

            moveInputX = Input.GetAxis("Horizontal");
            moveInputY = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector2(moveInputX * speed, moveInputY * speed);
        }
    }
    void upsideDown()
    {
        rGravity = !rGravity;
        rb2d.gravityScale = rb2d.gravityScale * -1;
        Vector3 scaler = transform.localScale;
        scaler.y *= -1;
        transform.localScale = scaler;
    }
   
}
