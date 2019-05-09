using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSlide : MonoBehaviour
{
   
    public Animator slideAnim;
    private bool slidOut;
    // Start is called before the first frame update
    void Start()
    {
        slideAnim.enabled = false;
        slidOut = false;
        
    }
    private void SlideIn()
    {
        slideAnim.enabled = true;
        slideAnim.Play("slideup");
    }
    private void SlideOut()
    {
        slideAnim.Play("slideup 0");
    }
    public void ToggleSlide()
    {
        if(slidOut == false)
        {
            SlideIn();
            slidOut = true;
        }
        else if(slidOut == true)
        {
            SlideOut();
            slidOut = false;
        }
    }
}
