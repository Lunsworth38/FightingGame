using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour
{
    public Transform pointOne;
    public Transform pointTwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pointOne.position, pointTwo.position, 0.5f);
    }
    

}
