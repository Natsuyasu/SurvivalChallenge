using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip musicOnStart;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Play(musicOnStart, true);
    }

    AudioClip swichTo;

    public void Play(AudioClip music, bool interrupt = false)
    {
        if(interrupt == true)
        {
            volume = 1f;
            audioSource.volume = volume;
            audioSource.clip = music;
            audioSource.Play();
        }
        else
        {
            swichTo = music;
            StartCoroutine(SmoothSwichMusic());
        }
        
        
    }

    float volume;
    [SerializeField] float timeToSwich;

    IEnumerator SmoothSwichMusic()
    {
        volume = 1f;

        while(volume > 0f)
        {
            volume -= Time.deltaTime / timeToSwich;
            if (volume < 0f) { volume = 0f; }
            audioSource.volume = volume;
            yield return new WaitForEndOfFrame();
        }

        Play(swichTo, true);
    }


}
