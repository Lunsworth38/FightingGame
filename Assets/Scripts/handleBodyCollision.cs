using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleBodyCollision : MonoBehaviour

{
    [SerializeField] AudioClip punchedSound;
    characterControl characterControl;

    // Start is called before the first frame update
    void Start()
    {
        characterControl = GetComponent<characterControl>();
    }

    public void OnPunch(float knockback, float damage, Vector3 knockbackDirection, float hitStopDuration)
    {
        Debug.Log("PUNCHED");
        characterControl.hit = true;
        characterControl.healthControl.LoseHealth(damage);
        characterControl.HitStop(Time.time, hitStopDuration);
        characterControl.applyHitForce(knockbackDirection * knockback);

    }

}
