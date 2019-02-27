using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanels : MonoBehaviour
{
    public GameObject pausepanel;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showPausePanel()
    {
        pausepanel.SetActive(true);
    }
    public void hidePausePanel()
    {
        pausepanel.SetActive(false);
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        Time.timeScale = 1;
    }
}
