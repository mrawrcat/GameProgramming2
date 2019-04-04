using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	//public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
    public GameObject gameOverPanel;
    public GameObject quitPanel;
    public GameObject creditsPanel;
    public GameObject tutorialButton;
    public GameObject shopPanel;
    public Animator pauseAnim, optionsAnim, gameOverAnim, quitAnim;

    private void Start()
    {
        pauseAnim = pausePanel.GetComponent<Animator>();
        optionsAnim = optionsPanel.GetComponent<Animator>();
        gameOverAnim = gameOverPanel.GetComponent<Animator>();
        quitAnim = quitPanel.GetComponent<Animator>();
        pauseAnim.enabled = false;
        optionsAnim.enabled = false;
        gameOverAnim.enabled = false;
        quitAnim.enabled = false;

    }

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
	{
        optionsAnim.enabled = true;
        optionsAnim.Play("OptionsPanelSlideIn");
	}
	public void HideOptionsPanel()
	{
        optionsAnim.Play("OptionsPanelSlideOut");   
    }
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	public void ShowPausePanel()
	{
        pauseAnim.enabled = true;
        pauseAnim.Play("PausePanelSlideIn");
    }
    public void HidePausePanel()
	{
        pauseAnim.Play("PausePanelSlideOut");
    }
    public void ShowgameOverPanel()
    {
        gameOverAnim.enabled = true;
        gameOverAnim.Play("GameOverPanelSlideIn");
        
    }
    public void HidegameOverPanel()
    {
        gameOverAnim.Play("GameOverPanelSlideOut");
        
    }
    public void ShowquitPanel()
    {
        quitAnim.enabled = true;
        quitAnim.Play("QuitPanelSlideIn");
    }
    public void HidequitPanel()
    {
        quitAnim.Play("QuitPanelSlideOut");
    }
    public void ShowcreditsPanel()
    {
        creditsPanel.SetActive(true);
        
    }

    //Call this function to deactivate and hide the Pause panel during game play
    public void HidecreditsPanel()
    {

       creditsPanel.SetActive(false);
        //optionsTint.SetActive(false);

    }
    public void ShowShopPanel()
    {
        shopPanel.SetActive(true);
    }
    public void HideShopPanel()
    {
        shopPanel.SetActive(false);
    }
    public void ShowTutorialButton()
    {
        tutorialButton.SetActive(true);
        
    }
    public void HideTutorialButton()
    {

        tutorialButton.SetActive(false);
        

    }
}
