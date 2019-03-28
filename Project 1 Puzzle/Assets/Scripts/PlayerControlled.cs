using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerControlled : MonoBehaviour {

    //public static PlayerController instance = null;
    //public ShowPanels showpanel;
    //private SoundManager soundmanager;
    //public Restart restartgame;
    public Text coinscoretext;
    public Text coinscoreshoptext;
    public Text healthtext;
    public Text maxHealthtext;
    public Text healthpricetext;
    public Text scoretext;
    public Text highscoretext;

    //Player variables
    public float movespeed;      //forward movement speed
    public bool isGrounded = false;
    public bool isPlaying = false;
    public float health = 1;
    public float maxhealth = 1;
    public float coinamt;
    public float score;
    public float highscore;
    public int healthprice;
    public float originalMovespeed = 2;
    //private bool powerActive;public float powerDown;
    public bool cantakedmg = true;
    private float movespeedHolder;
    private Animator anim;                  //reference to the animator component
    private Rigidbody2D rb2d;
    private SpriteRenderer mySpriteRenderer;
    private bool flip;


    void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {       
        //get reference to the animator component
        anim = GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        //showpanel = FindObjectOfType<ShowPanels>();
        //soundmanager = FindObjectOfType<SoundManager>();
        //restartgame = FindObjectOfType<Restart>();
    }
	
	// Update is called once per frame

    void FixedUpdate()
    {
        move(movespeed);
        showText();
        updateScore();
        keephighscore();
        flipSprite();
    }
    public void move(float move)
    {
        rb2d.velocity = new Vector2(movespeed, rb2d.velocity.y);

    }
    void updateScore()
    {
        if(isPlaying == true)
        {
            score += 10 * Time.deltaTime;
        }
    }
    public void flipGravity()
    {

        rb2d.gravityScale *= -1;
        flip = !flip;
        
    }
    void flipSprite()
    {
        if(flip == true)
        {
            mySpriteRenderer.flipY = true;
        }
        else
        {
            mySpriteRenderer.flipY = false;
        }
    }
    void EnableDoubleJump()
    {
        //canDoubleJump = true;
    }
    void showText()
    {
        scoretext.text = "Score: " + Mathf.Round(score);
        highscoretext.text = "Highscore: " + Mathf.Round(highscore);
        coinscoretext.text = "Fish: " + Mathf.Round(coinamt);
        coinscoreshoptext.text = "Fish: " + Mathf.Round(coinamt);
        healthtext.text = "Health: " + Mathf.Round(health);
        maxHealthtext.text = "Lives: " + Mathf.Round(maxhealth);
        healthpricetext.text = healthprice.ToString();

    }
    void keephighscore()
    {
        if(score > highscore)
        {
            highscore = score;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            takeDamage(1);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.CompareTag("Fish"))
        {
            //stats.coinamt++;
            Debug.Log("coin get");
            //score += 10;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            anim.SetBool("Grounded", true);
            isGrounded = true;
            
            //canDoubleJump = false;
            
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            anim.SetBool("Grounded", true);
            isGrounded = true;
            
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            anim.SetBool("Grounded", false);
            isGrounded = false;
            
        }
    }
    
    //public void runFaster()
    //{
    //    if(ammo > 0 && !powerActive)
    //    {
    //        //powerDown += Time.deltaTime;
    //        powerActive = true;
    //        ammo--;
    //        movespeedHolder = movespeed;
    //        movespeed *= 2;
    //        Debug.Log("run fast clicked");
    //        Invoke("powerUpDown", powerDown);
    //    }
        
       
    //}
    //void powerUpDown()
    //{
    //    powerActive = false;
    //    movespeed = movespeedHolder;
    //}
    
   
   public void takeDamage(int dmg)
    {
        if(cantakedmg == true)
        {
            health -= dmg;
            cantakedmg = false;
            Invoke("canDmgAgain", 0.2f);
        }
        if(health <= 0)
        {
            GameOver();
            //restartgame.removeObjects();
        }
        
    }
    
   public void canDmgAgain()
    {
        cantakedmg = true;
    } 
    
    
    public void GameOver()
    {
        //soundmanager.StopGameMusic();
        //soundmanager.PlaySingle();
        //showpanel.ShowgameOverPanel();
        Debug.Log("Gameover");
        Save();
        isPlaying = false;
        
        //Time.timeScale = 0f;
        //anim.SetBool("Hit", false);
    }

    public void increaseMaxHealth()
    {
        if (maxhealth < 7 && coinamt >= healthprice)
        {
            maxhealth++;
            coinamt -= healthprice;
            healthprice *= 2;
        }
    }

    public void startPlay()
    {
        isPlaying = true;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();
        data.highscore = highscore;
        data.coins = coinamt;
        data.maxhealth = maxhealth;
        data.healthprice = healthprice;
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
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            highscore = data.highscore;
            coinamt = data.coins;
            maxhealth = data.maxhealth;
            healthprice = data.healthprice;
           Debug.Log("File Loaded");
        }
    }
    [Serializable]
    class PlayerData
    {
        public float highscore;
        public float coins;
        public float maxhealth;
        public int healthprice;

    }
}
