using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHelper : MonoBehaviour
{
    public Slider volslide;
    public Button muteButton;
    /*
    public Sprite OnSprite;
    public Sprite OnSpritePressed;
    public Sprite OffSprite;
    public Sprite OffSpritePressed;
    private SpriteState spriteState;
    */
    // Start is called before the first frame update
    void Start()
    {
       // spriteState = muteButton.spriteState;
        //muteToggleAppearance();
        if(MusicController.musicControl.audiofunc.mute == true)
        {
           // muteButton.image.sprite = OffSprite;
           // spriteState.pressedSprite = OffSpritePressed;
            
        }
        if (MusicController.musicControl.audiofunc.mute == false)
        {
           // muteButton.image.sprite = OnSprite;
           // spriteState.pressedSprite = OnSpritePressed;

        }

    }

    // Update is called once per frame
    void Update()
    {
        volslide.value = MusicController.musicControl.audiofunc.volume;
    }
    void muteToggleAppearance()
    {
        //muteToggle.isOn = !muteToggle.isOn;
        
        
    }
    public void muteAudio()
    {
        //MusicController.musicControl.ToggleMute();
        MusicController.musicControl.audiofunc.mute = !MusicController.musicControl.audiofunc.mute;
    }
    public void slideAudio()
    {
        //MusicController.musicControl.audiofunc = MusicController.musicControl.
        MusicController.musicControl.audiofunc.volume = volslide.value;
    }
   
}
