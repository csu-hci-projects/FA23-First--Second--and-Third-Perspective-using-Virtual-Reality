using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateAroundCrane : MonoBehaviour
{
    public GameObject target;//the target object 
    public float speedMod = 10.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at
    float gripR;
    float gripL;

    void Start()
    {//Set up things on the start method
       
    }

    void Update()
    {
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it
        gripL = OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger, OVRInput.Controller.LTouch);
        gripR = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger, OVRInput.Controller.RTouch);
        //makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), (gripL-gripR) * Time.deltaTime * speedMod);
    }
}
