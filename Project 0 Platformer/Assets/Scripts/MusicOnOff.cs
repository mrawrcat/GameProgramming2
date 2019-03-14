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

    private void Update()
    {
        ChangeImage();
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
    
}
