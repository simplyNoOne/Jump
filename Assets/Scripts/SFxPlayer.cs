using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFxPlayer : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource getPoint;
    public AudioSource losePoint;
    public bool mute;

    private void Start()
    {
        Save save = GetComponentInParent<Save>();
        save.LoadFile();
        mute = save.SFXmuted;
    }

    public void PlayJump()
    {
        if(!mute)
            jump.Play();
    }

    public void PlayGetP()
    {
        if (!mute)
            getPoint.Play();
    }

    public void PlayLoseP()
    {
        if (!mute)
            losePoint.Play();
    }

    
}
