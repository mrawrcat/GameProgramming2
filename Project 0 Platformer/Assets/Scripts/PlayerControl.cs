using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed, jumpforce;
    private Rigidbody2D rb2d;
    public bool canControl, doneDance;
    private Animator anim;
    public GameObject finishScreen;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            howmove();
        }
        //finishCheck();
    }
    void move(float howfast)
    {
        rb2d.velocity = new Vector2(howfast, rb2d.velocity.y);
    }
    void howmove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            move(-speed);
            anim.SetBool("isMoving", true); 
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("isMoving", false);
        }
            if (Input.GetKey(KeyCode.D))
        {
            move(speed);
            anim.SetBool("isMoving", true);
        }
            else if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("isMoving", false);
        }
    }
    void finishCheck()
    {
        if (doneDance)
        {
            StartCoroutine(dancetwo());
        }
    }
    IEnumerator dancetwo()
    {
        canControl = false;
        //anim.SetBool("finished", true);
        yield return new WaitForSeconds(5);
        
        finishScreen.SetActive(true);
        
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Door"))
    //    {
    //        doneDance = true;
    //        Debug.Log("hitdoor");
    //    }
    //}

}
