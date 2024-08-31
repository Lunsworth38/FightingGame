using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MouseAim : MonoBehaviour
{
    [SerializeField] float maxDistanceFromPlayer;
    float currentDistanceFromPlayer;
    float mouseVertInput;
    float mouseHorizInput;
    [SerializeField] GameObject player;
    characterControl control;
    // Start is called before the first frame update
    void Start()
    {
        control = player.GetComponent<characterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseVertInput = Input.GetAxis(control.aimYInput);
        mouseHorizInput = Input.GetAxis(control.aimXInput);

        Vector3 newPos = transform.position + transform.TransformDirection(mouseHorizInput, mouseVertInput, 0);
        
        float radius = maxDistanceFromPlayer; //radius of *black circle*
        Vector3 centerPosition = player.transform.position; //center of *black circle*
        float distance = Vector3.Distance(newPos, centerPosition); //distance from ~green object~ to *black circle*

        if (distance > radius) //If the distance is less than the radius, it is already within the circle.
        {
            Vector3 fromOriginToObject = newPos - centerPosition; //~GreenPosition~ - *BlackCenter*
            fromOriginToObject *= radius / distance; //Multiply by radius //Divide by Distance
            newPos = centerPosition + fromOriginToObject; //*BlackCenter* + all that Math
        }
        transform.position = newPos;
    }
}
