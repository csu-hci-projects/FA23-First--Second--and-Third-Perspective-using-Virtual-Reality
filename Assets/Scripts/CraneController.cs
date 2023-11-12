using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    public GameObject GrabArea;
    public Grabbable Grabbable;
    public float speed = 4f;
    public float rot = 65f;
    public GameObject RopeConnector;
    public GameObject Grabber;
    bool isCollideFBMax=false;
    bool isCollideFBMin=false;
    bool isGrabbed=false;
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
        if ((isCollideFBMax && (stickUpDown>0)) || (isCollideFBMin && (stickUpDown < 0)))
        {
            stickUpDown = 0;
        }
        RopeConnector.transform.position += -stickUpDown * speed * Time.deltaTime * transform.right;
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
        if (Grabbable.isNearGrabbable && Grabbable.NearGrabbableObject != null && !isGrabbed)
        {
            Destroy(Grabbable.NearGrabbableObject.GetComponent<Rigidbody>());
            Grabbable.NearGrabbableObject.transform.SetParent(GrabArea.transform);
            isGrabbed = true;
            print("grabbed: " + Grabbable.NearGrabbableObject.name);
        }
    }
    public void UnGrab()
    {
        print("UnGrab");
        if (isGrabbed)
        {
            Grabbable.NearGrabbableObject.transform.SetParent(null);
            Grabbable.NearGrabbableObject.AddComponent<Rigidbody>();
            isGrabbed = false;
            print("ungrabbed: " + Grabbable.NearGrabbableObject.name);
        }
    }
    public void ifCollideThenDisable(bool isMax)
    {
        if(isMax) { isCollideFBMax = true; }
        else { isCollideFBMin = true; }
    }
    public void ifNotCollideThenEnable(bool isMax)
    {
        if(isMax) { isCollideFBMax = false; }
        else { isCollideFBMin = false; }
    }
}
