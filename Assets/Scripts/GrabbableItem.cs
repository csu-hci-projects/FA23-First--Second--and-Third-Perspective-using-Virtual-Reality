using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrabbableItem : MonoBehaviour
{
    // Reference to the rigidbody
    public bool isGrabbableItemGrabbed = false;
    private Rigidbody rb;
    public Rigidbody Rb => rb;
    bool isMove = false;
    public Vector3 targetPosition;
    public float speed = 10;
    /// <summary>
    /// Method called on initialization.
    /// </summary>
    private void Awake()
    {
        // Get reference to the rigidbody
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            //print("moving");
            if (transform.position == targetPosition)
            {
                //print("deleting");
                transform.gameObject.SetActive(false);
            }
        }
    }
    public void MoveToBack(Vector3 MoveToBackPosition)
    {
        isMove = true;
        targetPosition = MoveToBackPosition;
    }
}
