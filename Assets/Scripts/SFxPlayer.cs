using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFxPlayer : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource getPoint;
    public AudioSource losePoint;


    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayGetP()
    {
        getPoint.Play();
    }

    public void PlayLoseP()
    {
        losePoint.Play();
    }

}
