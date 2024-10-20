using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 1f;  // The distance of the downward raycast
    [SerializeField] private LayerMask gravelLayer;  // Layer mask for the gravel layer

    [SerializeField] private AudioClip[] stepsSound;
    private AudioSource audioSourceSteps;
    [SerializeField] private AudioMixerGroup stepsMixer;

    [SerializeField] private AudioClip[] takePictureSound;
    private AudioSource audioSourceTakePicture;
    [SerializeField] private AudioMixerGroup takePictureMixer;

    [SerializeField] private AudioClip[] stepsGravelSound;
    private AudioSource audioSourceStepsGravel;
    [SerializeField] private AudioMixerGroup stepsGravelMixer;

    [SerializeField] private AudioClip[] blockBreakingSound;
    private AudioSource audioSourceBlockBreaking;
    [SerializeField] private AudioMixerGroup blockBreakingMixer;

    [SerializeField] private AudioClip[] pickUpSound;
    private AudioSource audioSourcePickUp;
    [SerializeField] private AudioMixerGroup pickUpMixer;

    [SerializeField] private AudioClip[] menuSound;
    private AudioSource audioSourceMenu;
    [SerializeField] private AudioMixerGroup menuMixer;

    [SerializeField] private float timeBetweenSteps;

    //private PlayerMovement playerScript;

    private float justStep;
    public bool OnGravel = false;

    [SerializeField] private bool isMonter = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceSteps = gameObject.AddComponent<AudioSource>();
        audioSourceSteps.outputAudioMixerGroup = stepsMixer;
        

        audioSourceTakePicture = gameObject.AddComponent<AudioSource>();
        audioSourceTakePicture.outputAudioMixerGroup = takePictureMixer;


        audioSourceStepsGravel = gameObject.AddComponent<AudioSource>();
        audioSourceStepsGravel.outputAudioMixerGroup = stepsGravelMixer;


        audioSourceBlockBreaking = gameObject.AddComponent<AudioSource>();
        audioSourceBlockBreaking.outputAudioMixerGroup = blockBreakingMixer;


        audioSourcePickUp = gameObject.AddComponent<AudioSource>();
        audioSourcePickUp.outputAudioMixerGroup = pickUpMixer;


        audioSourceMenu = gameObject.AddComponent<AudioSource>();
        audioSourceMenu.outputAudioMixerGroup = menuMixer;

        audioSourceBlockBreaking.playOnAwake = false;

        audioSourceTakePicture.volume = 1f;
        audioSourceSteps.volume = 1f;
        audioSourceStepsGravel.volume = 1f;
        audioSourceBlockBreaking.volume = 1f;
        audioSourcePickUp.volume = 1f;
        audioSourceMenu.volume = 1f;


        //audioSourcePickUp.clip = pickUpSound;


        //playerScript = GetComponent<PlayerMovement>();

        justStep = timeBetweenSteps;



    }


    private void Update()
    {
        // if (Time.time - justStep > timeBetweenSteps && !isMonter)
        // {
            
        //     if (playerScript.GetHasSpeed())
        //     {
        //         justStep = Time.time;

        //             PlayStepsSound();
        //     }
        // }
    }

    void CheckIfOnGravel()
    {
        // Step 1: Cast a ray straight down from the object's position
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Step 2: Perform the raycast and check if it hits something on the gravel layer
        if (Physics.Raycast(ray, out hit, raycastDistance, gravelLayer))
        {
            // The raycast hit an object on the "Gravel" layer
            OnGravel = true;
            Debug.Log("Standing on Gravel.");
        }
        else
        {
            // The raycast did not hit anything on the gravel layer
            OnGravel = false;
            Debug.Log("Not on Gravel.");
        }
    }

    public void PlayStepsSound()
    {
        audioSourceSteps.clip = stepsSound[Random.Range(0, stepsSound.Length)];
        audioSourceSteps.pitch = Random.Range(0.95f, 1.05f);

        audioSourceSteps.Play();
    }

    public void PlayTakePictureSound()
    {
        audioSourceTakePicture.clip = takePictureSound[Random.Range(0, takePictureSound.Length)];
        audioSourceTakePicture.pitch = Random.Range(0.95f, 1.05f);

        audioSourceTakePicture.Play();
    }

    public void PlayStepsGravelSound()
    {
        audioSourceStepsGravel.clip = stepsGravelSound[Random.Range(0, stepsGravelSound.Length)];
        audioSourceStepsGravel.pitch = Random.Range(0.95f, 1.05f);

        audioSourceStepsGravel.Play();
    }

    public void PlayBlockBreakingSound()
    {
        audioSourceBlockBreaking.clip = blockBreakingSound[Random.Range(0, blockBreakingSound.Length)];
        audioSourceBlockBreaking.pitch = Random.Range(0.95f, 1.05f);

        audioSourceBlockBreaking.Play();
    }

    public void PlayPickUpSound()
    {
        audioSourcePickUp.clip = pickUpSound[Random.Range(0, pickUpSound.Length)];
        audioSourcePickUp.pitch = Random.Range(0.95f, 1.05f);

        audioSourcePickUp.Play();
    }

    public void PlayMenuSound()
    {
        audioSourceMenu.clip = menuSound[Random.Range(0, menuSound.Length)];
        audioSourceMenu.pitch = Random.Range(0.95f, 1.05f);

        audioSourceMenu.Play();
    }

}
