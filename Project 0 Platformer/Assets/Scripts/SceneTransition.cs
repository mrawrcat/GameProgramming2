using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    //public static SceneTransition instance = null;
    //public Animator anim;
    //public SoundManager soundmanager;
    //public AudioClip clip;
    Scene scene;
    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else if (instance != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //    DontDestroyOnLoad(gameObject);

    //    //soundmanager = FindObjectOfType<SoundManager>();

    //}



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(playThenLoad());
            //anim.Play("Start");
            //SceneManager.LoadScene("GravityMeowMain");
        }
    }

    //public void loadScene()
    //{
    //    StartCoroutine(playThenLoad());
    //}

    //IEnumerator playThenLoad()
    //{
    //    //anim.SetTrigger("end");
    //    yield return new WaitForSeconds(1f);
    //    SceneManager.LoadScene("GravityMeowMain");
    //    //soundmanager.PlayBG2();


    //}
    public void reload()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log(scene.name);
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void loadlvl()
    {
        SceneManager.LoadScene(1);
    }
    public void load1()
    {
        SceneManager.LoadScene("1");
    }
    public void load2()
    {
        SceneManager.LoadScene("2");
    }
    public void load3()
    {
        SceneManager.LoadScene("3");
    }
    public void load4()
    {
        SceneManager.LoadScene(5);
    }
}
