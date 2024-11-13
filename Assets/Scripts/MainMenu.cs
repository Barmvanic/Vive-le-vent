using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource Source;
    public AudioClip Music;

    void Start()
    {
        Source.clip = Music;
        Source.Play();
        
    }
}
