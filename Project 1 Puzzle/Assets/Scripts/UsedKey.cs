using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedKey : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void usethekey()
    {
        bool playerhaskey = gameObject.GetComponentInParent<PlayerPlusGhost>().usedKey;
        if (playerhaskey == true)
        {
           
            gameObject.GetComponentInChildren<Key>().gameObject.SetActive(false);
            playerhaskey = false;
        }
    }
}
