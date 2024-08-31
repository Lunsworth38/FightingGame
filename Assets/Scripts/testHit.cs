using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testHit : MonoBehaviour
{
    BoxCollider boxCollider;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = scale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("hit");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitTrig");
        if (other.CompareTag("attackBox"))
        {

        transform.localScale = transform.localScale * 2;
        }
    }



}
