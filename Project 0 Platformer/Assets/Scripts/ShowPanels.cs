using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowPanels : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject pausePanel;
    public GameObject lvlcompletePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showGameOverPanel()
    {

        GameOverPanel.SetActive(true);
        
        
    }
    public void hideGameOverPanel()
    {
        Unpause();
    }
    public void showPausePanel()
    {
        pausePanel.SetActive(true);
        Pause();
    }
    public void hidePausePanel()
    {
        pausePanel.SetActive(false);
        Unpause();
    }
    public void showCompletePanel()
    {
        lvlcompletePanel.SetActive(true);
        Pause();
    }
    public void hideCompletePanel()
    {
        lvlcompletePanel.SetActive(false);
        Unpause();
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
