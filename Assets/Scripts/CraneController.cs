using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class CraneController : MonoBehaviour
{
    public GameObject GrabArea;
    //public GrabberSphere GrabberSphere;
    public float speed = 4f;
    public float rot = 65f;
    public GameObject RopeConnector;
    public GameObject Grabber;
    bool isCollideFBMax=false;
    bool isCollideFBMin=false;
    bool isGrabbed=false;
    GameObject grabbedObject;
    [HideInInspector]public bool isNearGrabbable = false;
    [HideInInspector] public GameObject NearGrabbableObject;
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
        if (isNearGrabbable && (NearGrabbableObject != null) && !isGrabbed)
        {
            grabbedObject = NearGrabbableObject;
            //Destroy(Grabbable.NearGrabbableObject.GetComponent<Rigidbody>());
            grabbedObject.GetComponent<GrabbableItem>().Rb.isKinematic = true;
            grabbedObject.GetComponent<GrabbableItem>().Rb.velocity = Vector3.zero;
            grabbedObject.GetComponent<GrabbableItem>().Rb.angularVelocity = Vector3.zero;
            grabbedObject.GetComponent<GrabbableItem>().isGrabbableItemGrabbed = true;
            grabbedObject.transform.SetParent(GrabArea.transform);
            grabbedObject.transform.localPosition = Vector3.zero;
            grabbedObject.transform.localEulerAngles = Vector3.zero;
            isGrabbed = true;
            print("grabbed: " + grabbedObject.name);
        }
        else
        {
            print("nothing to grab");
        }
    }
    public void UnGrab()
    {
        if (isGrabbed)
        {
            grabbedObject.transform.SetParent(null);
            //Grabbable.NearGrabbableObject.AddComponent<Rigidbody>();
            grabbedObject.GetComponent<GrabbableItem>().Rb.isKinematic = false;
            grabbedObject.GetComponent<GrabbableItem>().isGrabbableItemGrabbed = false;
            isGrabbed = false;
            print("ungrabbed: " + grabbedObject.name);
        }
        else
        {
            print("nothing to ungrab");
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
    public void GrabberSphereOnTriggerEnter(Collider other)
    {        
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        isNearGrabbable = true;
        NearGrabbableObject = other.gameObject;
    }
    public void GrabberSphereOnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.gameObject.name);
        isNearGrabbable = false;
        NearGrabbableObject = null;
    }
}
