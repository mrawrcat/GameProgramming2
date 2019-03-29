using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer render;
    private PlayerController player;
    public float speed;
    public float platcolor;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerController>();
        platcolor = Random.Range(0, 3);
        if(platcolor == 0)
        {
            render.color = Color.blue;
        }
        if (platcolor == 1)
        {
            render.color = Color.red;
        }
        if (platcolor == 2)
        {
            render.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
       
        if(this.transform.position.x < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.GetComponent<SpriteRenderer>().color = render.color;
        }
    }
}
