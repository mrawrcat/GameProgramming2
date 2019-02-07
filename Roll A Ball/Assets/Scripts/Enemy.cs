using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(waitandadd());
    }

    private IEnumerator waitandadd()
    {
        yield return new WaitForSeconds(5.0f);
        rb.AddForce(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5), ForceMode.Impulse);
        Debug.Log("enemy movement");
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Wall")
        {
            StartCoroutine(waitandadd());
        }
        if(collision.collider.tag == "Player")
        {
            
            player.ShowgameOverPanel();
            Time.timeScale = 0;


        }
        
    }
}
