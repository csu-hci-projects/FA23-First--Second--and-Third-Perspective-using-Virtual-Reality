using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBackwardCollider : MonoBehaviour
{
    public CraneController CraneController;
    public bool isMax;
    void OnTriggerEnter(Collider other)
    {
        // Check the tag of the other GameObject
        if (other.gameObject.CompareTag("MoveForwardBackwardCollider"))
        {
            // Code to execute when the trigger is entered by an object with the specified tag
            Debug.Log("Trigger entered by: " + other.gameObject.name);
            CraneController.ifCollideThenDisable(isMax);
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Check the tag of the other GameObject
        if (other.gameObject.CompareTag("MoveForwardBackwardCollider"))
        {
            // Code to execute when the trigger is entered by an object with the specified tag
            Debug.Log("Trigger exited by: " + other.gameObject.name);
            CraneController.ifNotCollideThenEnable(isMax);
        }
    }
}
