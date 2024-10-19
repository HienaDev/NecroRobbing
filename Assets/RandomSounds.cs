using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] clip;
    [SerializeField] private float volume = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f;
        audioSource.volume = volume;

        
    }


    public void PlaySound()
    {
        audioSource.clip = clip[Random.Range(0, clip.Length)];
        audioSource.pitch = Random.Range(0.95f, 1.05f);

        audioSource.Play();
    }
}
