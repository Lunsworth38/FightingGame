using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class manageSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] footSteps;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landingSound;

    AudioSource audioSource;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playFootstep()
    {
        var randomIndex = Random.Range(0, footSteps.Length);
        audioSource.clip = footSteps[randomIndex];
        audioSource.Play();
    }

    void playJumpSound()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }
    

    void playLandingSound()
    {
        audioSource.clip = landingSound;
        audioSource.Play();
    }
}
