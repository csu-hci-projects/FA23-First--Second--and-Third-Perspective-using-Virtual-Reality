using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public float speed = 4f;
    public float rot = 65f;
    public GameObject RopeConnector;
    public GameObject Grabber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveForwardBackward(float stickUpDown)
    {
        RopeConnector.transform.position += stickUpDown * speed * Time.deltaTime * transform.forward;
    }
    public void MoveUpDown(float Stick2UpDown)
    {
        Grabber.transform.position += Stick2UpDown * speed * Time.deltaTime * transform.up;
    }
    public void RotateLeftRight(float stickLeftRight)
    {
        transform.Rotate(new Vector3(0, stickLeftRight * rot, 0) * Time.deltaTime);
    }
    public void Grab()
    {
        print("Grab");
    }
    public void UnGrab()
    {
        print("UnGrab");
    }
}
