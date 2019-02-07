using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Scene scene;
    public float speed, jumpforce;
    private Rigidbody rb;
    public int score, highscore;
    public Text scoretext, highscoretext;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        rb.AddForce(movement * speed);
        Jump();
        showtext();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpforce, 0, ForceMode.Impulse);
        }
        
    }
   private void showtext()
   {
       scoretext.text = "Score: " + score;
       highscoretext.text = "HighScore: " + highscore;
   }

    public void reload()
    {
        Time.timeScale = 1;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log(scene.name);
    }
    public void ShowgameOverPanel()
    {
        gameOverPanel.SetActive(true);

    }
}
