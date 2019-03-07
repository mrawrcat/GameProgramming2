using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text timetext;
    public float countdown;
    public GameObject GameOverPanel;
    private PlayerController playerControl;

    // Start is called before the first frame update
    void Start()
    {
        playerControl = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else if (countdown <= 0)
        {
            Debug.Log("GameOver");
            showGameOverPanel();
        }
        showtext();
    }

    void showtext()
    {
        timetext.text = "Time Remaining: " + Mathf.Round(countdown);
    }
    public void showGameOverPanel()
    {
        GameOverPanel.SetActive(true);
        playerControl.canControl = false;
    }
}
