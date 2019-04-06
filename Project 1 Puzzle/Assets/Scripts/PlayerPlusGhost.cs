using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlusGhost : MonoBehaviour
{
    public float speed, jumpforce, jumptime, checkradius;
    public Transform groundcheck;
    public LayerMask whatIsGround;
    public bool bodyControl, isjump, ghosted, onSurface, isInteract, gotKey, usedKey;
    public float moveInputX, moveInputY;
    public bool faceR = true, isGrounded = true, rGravity;
    private Rigidbody2D rb2d;
    private Animator anim;
    private LineRenderer line;
    public GameObject shackle, ghostTint;
    private float startWidth = .05f, endWidth = .05f, jumpcounter;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        bodyControl = true;
        ghosted = false;
        isjump = false;
        isInteract = false;
        gotKey = false;
        usedKey = false;

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
                isjump = true;
                jumpcounter = jumptime;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rb2d.velocity = Vector2.up * jumpforce;
                isjump = true;
                jumpcounter = jumptime;

            }
            if (Input.GetKey(KeyCode.W) && isjump == true)
            {
                if(jumpcounter > 0)
                {
                    rb2d.velocity = Vector2.up * jumpforce;
                    jumpcounter -= Time.deltaTime;
                }
                else
                {
                    isjump = false;
                }
            }
            if (Input.GetKey(KeyCode.UpArrow) && isjump == true)
            {
                if (jumpcounter > 0)
                {
                    rb2d.velocity = Vector2.up * jumpforce;
                    jumpcounter -= Time.deltaTime;
                }
                else
                {
                    isjump = false;
                }

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
            ghostTint.SetActive(true);
            //rb2d.mass = 1000000;
        }
        if (ghosted == false)
        {
            anim.SetBool("isGhost", false);
            shackle.transform.position = transform.position;
            shackle.SetActive(false);
            ghostTint.SetActive(false);
            //rb2d.mass = 1;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInteract)
            {
                //upsideDown();
            }
           
        }
        
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatIsGround);
        Facing();
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, shackle.transform.position);

    }
    void FixedUpdate()
    {

        if (bodyControl)
        {
            if (!onSurface)
            {
                moveInputX = Input.GetAxis("Horizontal");
                rb2d.velocity = new Vector2(moveInputX * speed, rb2d.velocity.y);
            }
           
           
            

            //moveInputY = Input.GetAxis("Vertical");
            //rb2d.velocity = new Vector2(moveInputX, rb2d.velocity.y);
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Conveyor")
        {
            if(collision.gameObject.GetComponent<SurfaceEffector2D>().speed != 0)
            {
                onSurface = true;
            }
            else
            {
                onSurface = false;
            }
            
            Debug.Log("On Conveyor");
        }
        if(collision.collider.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Conveyor")
        {
            onSurface = false;
            Debug.Log("Off Conveyor");
        }
        if (collision.collider.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
    
    public void startClimbLedge()
    {
        StartCoroutine(ClimbLedge());
    }
    IEnumerator ClimbLedge()
    {
        //anim.SetBool("isClimb", true);
        bodyControl = false;
        transform.position = new Vector2(transform.position.x, transform.position.y);
        rb2d.gravityScale = 0;
        rb2d.velocity = new Vector2(0, 0);
        anim.SetBool("isClimb", true);
        yield return new WaitForSeconds(.5f);
        transform.position = new Vector2(transform.position.x + .5f * transform.localScale.x, transform.position.y + .5f);
        rb2d.gravityScale = 3;
        rb2d.velocity = new Vector2(moveInputX * speed, rb2d.velocity.y);
        anim.SetBool("isClimb", false);
        bodyControl = true;
        yield return null;
    }

}
