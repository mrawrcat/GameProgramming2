using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXControl : MonoBehaviour
{
    public static SFXControl sfxControl;
    public AudioSource[] sfxfunc;
    private int sfxAudio;
    // Start is called before the first frame update
    void Awake()
    {
        if (sfxControl == null)
        {
            sfxControl = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (sfxControl != this)
        {
            Destroy(gameObject);
        }
        //sfxfunc = GetComponent<AudioSource>();
        //foreach (AudioSource sfx in sfxfunc)
        //{
        //    sfxfunc[sfxAudio] = sfxfunc[sfxAudio].GetComponent<AudioSource>();
        //    sfxAudio++;
        //}
    }
}
