using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsScript : MonoBehaviour
{
    [field:SerializeField] public AudioClip SoundToPlay { get; set; }
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void PlayAudio()
    {
        audioSource.clip = SoundToPlay;
        audioSource.Play();
    }
}
