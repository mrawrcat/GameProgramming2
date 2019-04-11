using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHelper : MonoBehaviour
{
   
    public Button muteButton;
    public void muteAudio()
    {
        //MusicController.musicControl.ToggleMute();
        MusicController.musicControl.audiofunc.mute = !MusicController.musicControl.audiofunc.mute;
    }
   
   
}
