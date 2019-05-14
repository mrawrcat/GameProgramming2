using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXOnOff : MonoBehaviour {

    public Sprite OnSprite;
    public Sprite OnSpritePressed;
    public Sprite OffSprite;
    public Sprite OffSpritePressed;
    public Button button;
    private SpriteState spriteState;

    
    private void Start()
    {
        if(Gamemanager.manager.sfxOnOff == 0)
        {
            SFXControl.sfxControl.sfxfunc[0].mute = true;
            SFXControl.sfxControl.sfxfunc[1].mute = true;
            SFXControl.sfxControl.sfxfunc[2].mute = true;
        }
    }
    private void Update()
    {
        ChangeImage();
        if(Gamemanager.manager.sfxOnOff == 1)
        {
            
            SFXControl.sfxControl.sfxfunc[0].mute = false;
            SFXControl.sfxControl.sfxfunc[1].mute = false;
            SFXControl.sfxControl.sfxfunc[2].mute = false;

        }
        else if(Gamemanager.manager.sfxOnOff == 0)
        {
            //MusicController.musicControl.audiofunc.mute = true;
            SFXControl.sfxControl.sfxfunc[0].mute = true;
            SFXControl.sfxControl.sfxfunc[1].mute = true;
            SFXControl.sfxControl.sfxfunc[2].mute = true;
        }
    }
    public void ChangeImage()
    {
        spriteState = button.spriteState;
        if (SFXControl.sfxControl.sfxfunc[0].mute == true)
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
    

    public void toggleMuteSfx()
    {
        Gamemanager.manager.SwitchSFX();
    }
}
