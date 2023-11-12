using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool isNearGrabbable=false;
    public GameObject NearGrabbableObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        // Check the tag of the other GameObject
        if (other.gameObject.CompareTag("Grabbable"))
        {
            // Code to execute when the trigger is entered by an object with the specified tag
            Debug.Log("Trigger entered by: " + other.gameObject.name);
            isNearGrabbable = true;
            NearGrabbableObject = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        // Check the tag of the other GameObject
        if (other.gameObject.CompareTag("Grabbable"))
        {
            // Code to execute when the trigger is entered by an object with the specified tag
            Debug.Log("Trigger exited by: " + other.gameObject.name);
            isNearGrabbable = false;
            NearGrabbableObject = null;
        }
    }
}
