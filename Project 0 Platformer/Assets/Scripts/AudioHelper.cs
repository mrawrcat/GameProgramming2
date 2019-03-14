using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHelper : MonoBehaviour
{
    public Slider volslide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void muteAudio()
    {
        MusicController.musicControl.ToggleMute();
    }
    public void slideAudio()
    {
        //MusicController.musicControl.audiofunc = MusicController.musicControl.
        MusicController.musicControl.audiofunc.volume = volslide.value;
    }
}
