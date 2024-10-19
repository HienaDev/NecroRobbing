using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public List<AudioSource> audioSources = new List<AudioSource>();

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void EnableAudioSources()
    {
        foreach (AudioSource audio in audioSources)
        {
            audio.UnPause();
        }
    }

    public void DisableAudioSources()
    {
        foreach (AudioSource audio in audioSources)
        {
            audio.Pause();
        }
    }
}
