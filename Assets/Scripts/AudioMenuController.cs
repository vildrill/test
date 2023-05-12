using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioMenuController : MonoBehaviour
{
    AudioSource audioMenu;
    // Start is called before the first frame update
    void Start()
    {
        audioMenu = GetComponentInChildren<AudioSource>();
        audioMenu.Play();
    }
    //Bật - tắt âm thanh
    public void MusicBGStatus()
    {
        if (audioMenu.isPlaying)
        {
            audioMenu.Pause();
        }
        else if (!audioMenu.isPlaying)
        {
            audioMenu.UnPause();
        }
    }
}

