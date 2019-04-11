using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public bool ghostControl;
    public float speed;
    public bool faceR = true;
    public GameObject player;
    private Rigidbody2D rb2d;
    private PlayerPlusGhost playerControl;
    private float moveInputX, moveInputY;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerControl = FindObjectOfType<PlayerPlusGhost>();
        ghostControl = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(playerControl.ghosted == false)
        {
            ghostControl = false;
            transform.position = playerControl.transform.position;
        }
        else if(playerControl.ghosted == true)
        {
            ghostControl = true;
            moveInputX = Input.GetAxis("Horizontal");
            moveInputY = Input.GetAxis("Vertical");
            rb2d.velocity = new Vector2(moveInputX * speed, moveInputY * speed);
            Facing();
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
}
