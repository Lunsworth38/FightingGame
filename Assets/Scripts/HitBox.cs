using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour

{
    public bool isActive;
    bool shouldActivate;
    bool shouldDeactivate;
    BoxCollider boxCollider;
    AudioSource audioSource;
    [SerializeField] AudioClip punchedSound;
    public float knockback = 1000;
    public float damage = 30;
    public characterControl characterControl;
    float hitStopDuration = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
    }

    public void setIsActive(bool value)
    {
        isActive = value;
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("PunchHit");
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            characterControl.HitStop(Time.time, hitStopDuration);
            audioSource.clip = punchedSound;
            audioSource.pitch = Random.Range(1.2f, 1.25f);
            audioSource.volume = 0.3f;
            audioSource.Play();
            other.gameObject.GetComponent<handleBodyCollision>().OnPunch(knockback, damage, characterControl.transform.forward, hitStopDuration);
            setIsActive(false);
        }
    }

}
