using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    // Start is called before the first frame update
    [SerializeField]AudioClip backgroundMusic;
    [Tooltip("The Audio Source that'll play the SFX")]
    [SerializeField]AudioSource sfxSource;
    [Tooltip("The SFX Clip that'll play when changing SFX volume")]
    [SerializeField]AudioClip sampleSFXClip;
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
    public void ChangeSFXVol(Slider slider)
    {
        sfxSource.volume=slider.value;
        PlaySFX(sampleSFXClip);
    }
    public void ChangeMusicVol(Slider slider)
    {
        audioSource.volume=slider.value;
    }
}
