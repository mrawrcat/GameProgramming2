using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostThrough : MonoBehaviour
{
    private PlayerController playercontrol;
    // Start is called before the first frame update
    void Start()
    {
        playercontrol = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
