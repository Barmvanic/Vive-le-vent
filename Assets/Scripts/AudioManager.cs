using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    
    public static void PlayWind(AudioSource WindSource)
    {
        
        WindSource.volume = 1f;
        WindSource.Play();
    }

    public static void StopWind(AudioSource WindSource)
    {
        WindSource.Stop();

    }

    public static void PlaySFX(AudioSource SFXSource, AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        audioSource.Stop();
        yield break;
    }
}
