using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;


public class Hero : MonoBehaviour {
    public static Hero Herocontrol;

    public float movespeed = 1; // player's movespeed
    public float basemovespeed = 1;
    public float movespeedCap;
    public float spawnpowerup;
    public float increaseSpeed;
    public float jump = 150f;
    public bool grounded;
    public float score;
    private float highscore;
    public float coins;
    public float keepcost;
    public Text scoreText;
    public Text highscoreText;
    public Text coinsText;
    public Text deathText;
    public int deathtype;
    public float pointsperSec;
    public bool increasing;
    public bool doublejump;
    public bool spawnfireball;

    private Rigidbody2D rb2d;
    private Animator anim;

    // Use this for initialization
    void Awake () {

        rb2d = gameObject.GetComponent<Rigidbody2D>();

        

        if (Herocontrol == null)
        {
            DontDestroyOnLoad(gameObject);
            Herocontrol = this;
        }
        else if (Herocontrol != this)
        {
            Destroy(gameObject);
        }

        
    }
	
	// Update is called once per frame
	void Update () {

        if (increasing == true)
        {
            score += pointsperSec * Time.deltaTime;
            if (score > highscore)
            {
                highscore = score;
            }
        }
        if (score > increaseSpeed)
        {
            movespeed = movespeed + .5f;
            basemovespeed = basemovespeed + .5f;
            increaseSpeed = increaseSpeed * 2;
            //pointsperSec = pointsperSec + 2;
        }
        if(score >= 600)
        {
            spawnfireball = true;
        }

        move(movespeed);

       
        showScore();
        showHighScore();
        showCoins();
        showDeath();
        //jumpnow();
        //anim.SetInteger("State", 1);

        
    }

    public void move(float move)
    {
        rb2d.velocity = new Vector2(movespeed, rb2d.velocity.y);

    }
    /*
    public void jumpnow()
    {

        if (Input.GetButton("Fire1") && grounded == true && !EventSystem.current.IsPointerOverGameObject())
        {

            rb2d.AddForce(new Vector2(0, jump));


        }
    }
     */
   
    

    public void jumpbutton()
     {

        if (grounded == true)
        {

            rb2d.AddForce(new Vector2(0f, jump));

        }
        else if(grounded == false && doublejump == true)
        {
            rb2d.AddForce(new Vector2(0f, jump));
            doublejump = false;
        }

    }

  
    void showDeath()
    {
        if(deathtype == 0)
        {
            deathText.text = "You fell down a pit and broke your neck";

        }
        if(deathtype == 1)
        {
            deathText.text = "You got bumped into a bat and it ate you";
        }
        if (deathtype == 2)
        {
            deathText.text = "You got roasted by a fireball";
        }
    }
    
    void showScore()
    {
        scoreText.text = "Score: " + Mathf.Round(score);
    }

    void showHighScore()
    {
        highscoreText.text = "Highscore: " + Mathf.Round(highscore);
    }
    void showCoins()
    {
        coinsText.text = "Coins: " + coins;
    }
    public void usecoins()
    {
        
        coins = coins - 50;
    }

    
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        HeroData data = new HeroData();
        data.highscore = highscore;
        data.coins = coins;
       
        bf.Serialize(file, data);
        file.Close();

        Debug.Log("File Saved");
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            HeroData data = (HeroData)bf.Deserialize(file);
            file.Close();

            highscore = data.highscore;
            coins = data.coins;
            
            Debug.Log("File Loaded");
        }
    }
    [Serializable]
    class HeroData
    {
        public float highscore;
        public float coins;
        
    }
}
