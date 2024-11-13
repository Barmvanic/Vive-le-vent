using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAudio : MonoBehaviour
{
    AudioSource _audioSource;
    // public AudioClip Music;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
