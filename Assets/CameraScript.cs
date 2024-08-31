using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Camera cam;
    public Transform pointOne;
    public Transform pointTwo;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float zoom = Mathf.Clamp(-Vector3.Distance(pointOne.position, pointTwo.position) -5 , -100, -12);
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, zoom);
    }
}
