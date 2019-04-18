using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gmanager;
    void Awake()
    {
        if (gmanager == null)
        {
            gmanager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (gmanager != this)
        {
            Destroy(gameObject);
        }
        
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
