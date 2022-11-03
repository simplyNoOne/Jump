using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource player;

    private bool muted;
    // Start is called before the first frame update
    void Start()
    {
        Save save = GetComponentInParent<Save>();
        save.LoadFile();
        muted = save.MUSICmuted;
        if (!muted)
            player.Play();
    }

    public void Muted()
    {
        player.Pause();
        muted = true;
    }

    public void Unmuted()
    {
        player.Play();
        muted = false;
    }
    
    
}
