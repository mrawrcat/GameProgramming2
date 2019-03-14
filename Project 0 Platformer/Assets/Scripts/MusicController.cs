using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public static MusicController musicControl;
    public AudioSource audiofunc;
    public Slider volslide;
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

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleMute()
    {
        audiofunc = GetComponent<AudioSource>();
        audiofunc.mute = !audiofunc.mute;
    }
    public void volumeSlider()
    {
        audiofunc = GetComponent<AudioSource>();
        audiofunc.volume = volslide.value;
        Debug.Log(volslide.value);
    }
}
