using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoAttachment : MonoBehaviour
{
    public GameObject truckBed;
    public float springForce = 50f;
    public float damper = 5f;
    private SpringJoint springJoint;
    private bool isAttached = false;

    void Start()
    {
        Rigidbody truckRigidbody = truckBed.GetComponent<Rigidbody>();
        if (truckRigidbody == null)
        {
            Debug.LogError("Truck bed does not have a Rigidbody component.");
            return;
        }

        springJoint = gameObject.AddComponent<SpringJoint>();
        springJoint.connectedBody = truckRigidbody;
        springJoint.spring = springForce;
        springJoint.damper = damper;
        springJoint.anchor = Vector3.zero;
        springJoint.connectedAnchor = truckBed.transform.InverseTransformPoint(transform.position);
        springJoint.autoConfigureConnectedAnchor = false;

        // Instead of setting springJoint.enabled, deactivate the SpringJoint component
        springJoint.gameObject.SetActive(false);
    }

    public void AttachCargo()
    {
        if (!isAttached)
        {
            // Instead of setting springJoint.enabled, activate the SpringJoint component
            springJoint.gameObject.SetActive(true);
            isAttached = true;
        }
    }

    public void DetachCargo()
    {
        if (isAttached)
        {
            // Instead of setting springJoint.enabled, deactivate the SpringJoint component
            springJoint.gameObject.SetActive(false);
            isAttached = false;
        }
    }
}
