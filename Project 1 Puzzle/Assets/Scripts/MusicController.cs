using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public static MusicController musicControl;
    public AudioSource audiofunc;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (musicControl == null)
        {
            musicControl = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (musicControl != this)
        {
            Destroy(gameObject);
        }
        audiofunc = GetComponent<AudioSource>();
    }

    
    
    
}
