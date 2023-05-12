using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioM1 : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip walk;
    AudioSource[] audioM1;
    // Start is called before the first frame update
    void Start()
    {
        audioM1 = GetComponentsInChildren<AudioSource>();
        audioM1[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        //nhấn phím N để đổi nhạc nền
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (audioM1[0].isPlaying)
            {
                audioM1[1].Play();
                audioM1[0].Stop();
            }
            else if (audioM1[1].isPlaying)
            {
                audioM1[0].Play();
                audioM1[1].Stop();
            }
        }
    }

    //
    int isCheck; // 2 bài nhạc khi bấm Toggle không bị trộn vào nhanh
    public void MusicBGStatus()
    {
        if (audioM1[0].isPlaying)
        {
            audioM1[0].Pause();
            isCheck = 0;
        }
        else if (audioM1[1].isPlaying)
        {
            audioM1[1].Pause();
            isCheck = 1;
        }
        else if (!audioM1[0].isPlaying && isCheck == 0)
        {
            audioM1[0].UnPause();
        }
        else if (!audioM1[1].isPlaying && isCheck == 1)
        {
            audioM1[1].UnPause();
        }

    }
    public void playAudioJump()
    {
        audioM1[2].Play();
    }

    public void playAudioWalk()
    {
        audioM1[3].Play();
    }

    public void playAudioHurt()
    {
        audioM1[4].Play();
    }

    public void playAudioDie()
    {
        audioM1[5].Play();
    }
    
        
    
}
