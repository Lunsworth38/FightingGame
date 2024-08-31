using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPistol : MonoBehaviour
{
    [SerializeField] GameObject bulletOrigin;
    [SerializeField] Rigidbody bullet;
    [SerializeField] float thrust;

    public void shoot()
    {
        Rigidbody p = Instantiate(bullet, bulletOrigin.transform.position, bulletOrigin.transform.rotation);
        p.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        p.AddRelativeForce(Vector3.forward * thrust);
    }
}
