using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToTop : MonoBehaviour
{
    public GameObject panel, top, canvas;
    public bool isOut;
    // Start is called before the first frame update
    void Start()
    {
        isOut = false;
    }

    public void parentPanel()
    {
        if(isOut == false)
        {
            panel.transform.parent = top.transform;
            isOut = true;
        }
        if(isOut == true)
        {
            panel.transform.parent = canvas.transform;
            isOut = false;
        }
        
    }
}
