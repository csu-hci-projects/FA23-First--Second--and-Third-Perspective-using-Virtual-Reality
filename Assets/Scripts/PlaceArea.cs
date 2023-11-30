using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GrabObject;

public class PlaceArea : MonoBehaviour
{
    public Vector3 MoveToBackPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Grabbable"))
        {
            if (!other.gameObject.GetComponent<GrabbableItem>().isGrabbableItemGrabbed)
            {
                other.gameObject.GetComponent<GrabbableItem>().Rb.isKinematic = true;
                other.gameObject.GetComponent<GrabbableItem>().Rb.velocity = Vector3.zero;
                other.gameObject.GetComponent<GrabbableItem>().Rb.angularVelocity = Vector3.zero;
                other.gameObject.GetComponent<GrabbableItem>().MoveToBack(MoveToBackPosition);
            }
        }
    }
}
