using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip audioBackGround;
    public static AudioManager current;
    public AudioClip highScoreFx;
    private AudioSource audioSource;

    void Awake()
    {
        if (current == null)
            current = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = highScoreFx;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    public void PlayBackGround()
    {
      
            audioSource = GetComponent<AudioSource>();

            audioSource.clip = audioBackGround;

            audioSource.volume = 0.5f;
            audioSource.Play();
    }



    public void ButtonMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
            audioSource.Play();
    }
}
