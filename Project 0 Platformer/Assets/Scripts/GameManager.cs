using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Gmgr;
    public float countdown;
    private PlayerController playerControl;
    private ShowPanels showPanel;
    public int crownNum, bomblife;
    public bool gotCrown = false, checkSaved;

    [HideInInspector]
    public Scene scene;
    void Awake()
    {
        if(Gmgr == null)
        {
            Gmgr = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if(Gmgr != this)
        {
            Destroy(gameObject);
        }
        Debug.Log("crown amt: " + PlayerPrefs.GetInt("crownNum"));
        crownNum = PlayerPrefs.GetInt("crownNum");
        showPanel = FindObjectOfType<ShowPanels>();
        playerControl = FindObjectOfType<PlayerController>();
        bomblife = 2;

    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
        //crownNum = PlayerPrefs.GetInt("crownNum");

    }
    void Countdown()
    {
        scene = SceneManager.GetActiveScene();
        
        if(scene.name.ToString() == "StartScreen")
        {
            countdown = 60;
        }
        else
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else if (countdown <= 0)
            {
                Debug.Log("GameOver");
                
                showPanel = FindObjectOfType<ShowPanels>();
                Debug.Log(showPanel.name);
                showPanel.showGameOverPanel();
                playerControl.canControl = false;
                
            }
            
        }
       

    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        Time.timeScale = 1;
    }
    public void scneSwitch(string scnename)
    {
        
        crownNum = PlayerPrefs.GetInt("crownNum");
        
        Debug.Log("crowns" + crownNum);
        gotCrown = false;
        //countdown = 60;
        SceneManager.LoadScene(scnename);

    }
    public void restartlvl()
    {
        
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        gotCrown = false;
        Unpause();
        
    }
    public void deletePrefs()
    {
        PlayerPrefs.DeleteAll();
        crownNum = PlayerPrefs.GetInt("crownNum");
    }
    public void resetCountdown()
    {
        countdown = 60;
    }
}
