//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Player : MonoBehaviour {

//    public float speed;
//    public float jumpforce;
//    public bool facingRight;
//    public bool isGrounded;
//    public bool isMoving;
//    private Animator anim;
//    private Rigidbody2D rb2d;
//    private SceneTransition scenetransition;
//    public SpriteRenderer mySpriteRenderer;
//    private ShowPanels showpanel;
//    public bool pushleft, pushright;
//    void Start () {
//        anim = GetComponent<Animator>();
//        rb2d = GetComponent<Rigidbody2D>();
//        mySpriteRenderer = GetComponent<SpriteRenderer>();
//        scenetransition = FindObjectOfType<SceneTransition>();
//        showpanel = FindObjectOfType<ShowPanels>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        howmove();
//        //jumpnow();
//        if (pushleft)
//        {
//            move((-speed));
//        }
//        if (pushright)
//        {
//            move((speed));
//        }

//    }
//    void move(float howfast)
//    {
//        rb2d.velocity = new Vector2(howfast, rb2d.velocity.y);
//        //if(isGrounded == true)
//        //{
//        //    anim.SetBool("isRunning", true);
//        //}
//    }
//    void howmove()
//    {
//        //want getkey for move left right and getkeydown for jump
//        if (Input.GetKey(KeyCode.LeftArrow))
//        {
//            isMoving = true;
//            mySpriteRenderer.flipX = false;
//            move((-speed));
            
//            //if(isGrounded == true)
//            //{
//            //    anim.SetBool("isRunning", true);
//            //}
            
            
//        }
//        if (Input.GetKey(KeyCode.RightArrow))
//        {
//            isMoving = true;
//            mySpriteRenderer.flipX = true;
//            move((speed));
//            //if (isGrounded == true)
//            //{
//            //    anim.SetBool("isRunning", true);
//            //}

//        }
//        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
//        {

//            isMoving = false;
//            //if (isGrounded == true)
//            //{
//            //    anim.SetBool("isRunning", false);
//            //}

//        }
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            anim.SetBool("isJumping", true);
//            rb2d.AddForce(new Vector2(0f, jumpforce));
//        }
//    }
//    public void jumpnow()
//    {
//        anim.SetBool("isJumping", true);
//        rb2d.AddForce(new Vector2(0f, jumpforce));
             
//    }
//    public void moveleft()
//    {
//        pushleft = true;
//        isMoving = true;
//        mySpriteRenderer.flipX = false;
        
//    }
//    public void moveright()
//    {
//        pushright = true;
//        isMoving = true;
//        mySpriteRenderer.flipX = true;
        
//    }
//    public void stopmoving()
//    {
//        pushleft = false;
//        pushright = false;
//        isMoving = false;
//        anim.SetBool("isRunning", false);
//    }
    
//    private void OnTriggerEnter2D(Collider2D col)
//    {
//        if (col.CompareTag("Deathcheck"))
//        {
//            scenetransition.reload();
//        }
//    }
//    private void OnCollisionEnter2D(Collision2D other)
//    {
//        if (other.collider.tag == "Ground" || other.collider.tag == "Grabable")
//        {
            
//            isGrounded = true;
//            if (isMoving == true)
//            {
//                anim.SetBool("isRunning", true);
//                anim.SetBool("isJumping", false);
//            }
//            else
//            {
//                anim.SetBool("isRunning", false);
//                anim.SetBool("isJumping", false);
//            }


//        }
//    }
//    private void OnCollisionStay2D(Collision2D other )
//    {
//        if (other.collider.tag == "Ground" || other.collider.tag == "Grabable")
//        {
            
//            isGrounded = true;
//            if (isMoving == true)
//            {
//                anim.SetBool("isRunning", true);
//                anim.SetBool("isJumping", false);
//            }
//            else
//            {
//                anim.SetBool("isRunning", false);
//                anim.SetBool("isJumping", false);
//            }
//        }
//    }
//    private void OnCollisionExit2D(Collision2D other)
//    {
//        if (other.collider.tag == "Ground" || other.collider.tag == "Grabable")
//        {
            
//            isGrounded = false;
//            //anim.SetInteger("State", 2);
//            anim.SetBool("isJumping", true);

//        }
//    }
//}
