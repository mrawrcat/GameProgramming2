using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchInteraction : MonoBehaviour
{
    RaycastHit2D hit;
    public float distance = .3f;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
            Debug.Log("pressed F");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
