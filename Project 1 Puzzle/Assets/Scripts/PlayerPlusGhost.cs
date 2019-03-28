using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlusGhost : MonoBehaviour
{
    public float speed, jumpforce, checkradius;
    public Transform groundcheck;
    public LayerMask whatIsGround;
    public bool bodyControl, isjump, canJump, ghosted;
    private float moveInputX, moveInputY;
    public bool faceR = true, isGrounded = true, rGravity;
    private Rigidbody2D rb2d;
    private Animator anim;
    private LineRenderer line;
    public GameObject shackle;
    private float startWidth = .05f, endWidth = .05f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        bodyControl = true;
        ghosted = false;
        isjump = false;
        canJump = true;


        // Add a Line Renderer to the GameObject
        line = this.gameObject.AddComponent<LineRenderer>();
        // Set the width of the Line Renderer
        line.startWidth = startWidth;
        line.endWidth = endWidth;
        //line.sortingOrder = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyControl)
        {
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb2d.velocity = Vector2.up * jumpforce;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
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
           

        }
        if (ghosted == true)
        {
            anim.SetBool("isGhost", true);
            shackle.SetActive(true);

        }
        if (ghosted == false)
        {
            anim.SetBool("isGhost", false);
            shackle.transform.position = transform.position;
            shackle.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            upsideDown();
        }
        
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, shackle.transform.position);

    }
    void FixedUpdate()
    {

        if (bodyControl)
        {
            //rb2d.gravityScale = 1;
            
            //rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
            //moveInputX = Input.GetAxis("Horizontal");
            //moveInputY = Input.GetAxis("Vertical");
            //rb2d.velocity = new Vector2(moveInputX, rb2d.velocity.y);

            if (Input.GetKey(KeyCode.A))
            {
                rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
                anim.SetBool("isRunning", true);
                Vector3 scaler = transform.localScale;
                scaler.x = -1;
                transform.localScale = scaler;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
                anim.SetBool("isRunning", true);
                Vector3 scaler = transform.localScale;
                scaler.x = 1;
                transform.localScale = scaler;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                anim.SetBool("isRunning", false);

            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                anim.SetBool("isRunning", false);

            }
            isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatIsGround);
            Facing();
            //if (moveInputX != 0 && isGrounded)
            //{
            //    anim.SetBool("isRunning", true);

            //}
            //else if (moveInputX == 0 && isGrounded)
            //{
            //    anim.SetBool("isRunning", false);
            //}

        }
        //else if (ghosted)
        //{
        //    moveInputX = Input.GetAxis("Horizontal");
        //    moveInputY = Input.GetAxis("Vertical");
        //    rb2d.velocity = new Vector2(moveInputX * speed, moveInputY * speed);
        //    Facing();
        //}

        else
        {
            //rb2d.velocity = new Vector2(0, rb2d.velocity.y);
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
        if (faceR && moveInputX < 0)
        {
            Flip();
        }
        else if (!faceR && moveInputX > 0)
        {
            Flip();
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
