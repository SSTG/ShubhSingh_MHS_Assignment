using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    // Start is called before the first frame update
    [SerializeField]AudioClip backgroundMusic;
    [SerializeField]AudioSource sfxSource;
    AudioSource audioSource;
    void Start()
    {

        audioSource=GetComponent<AudioSource>();
        audioSource.clip=backgroundMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.clip=sfxClip;
        sfxSource.Play();
    }
}
