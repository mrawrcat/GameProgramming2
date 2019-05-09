using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour {

    public Sprite OnSprite;
    public Sprite OnSpritePressed;
    public Sprite OffSprite;
    public Sprite OffSpritePressed;
    public Button button;
    private SpriteState spriteState;
    private void Start()
    {
        if(Gamemanager.manager.MusicOnOff == 0)
        {
            MusicController.musicControl.audiofunc.mute = true;
        }
    }
    private void Update()
    {
        ChangeImage();
        if(Gamemanager.manager.MusicOnOff == 1)
        {
            
            MusicController.musicControl.audiofunc.mute = false;
            
        }
        else if(Gamemanager.manager.MusicOnOff == 0)
        {
            MusicController.musicControl.audiofunc.mute = true;
            
        }
    }
    public void ChangeImage()
    {
        spriteState = button.spriteState;
        if (MusicController.musicControl.audiofunc.mute == true)
        {
            button.image.sprite = OffSprite;
            spriteState.pressedSprite = OffSpritePressed;
        }    
        else
        {
            button.image.sprite = OnSprite;
            spriteState.pressedSprite = OnSpritePressed;
        }
    }
    
    public void toggleMuteBG()
    {
        //MusicController.musicControl.audiofunc.mute = !MusicController.musicControl.audiofunc.mute;
        Gamemanager.manager.SwitchMusic();
        
    }
}
