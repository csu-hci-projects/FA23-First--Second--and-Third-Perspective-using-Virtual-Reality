using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMover : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float rotationSpeed = 2f;
    public CargoAttachment cargoAttachment; // Reference to the CargoAttachment script
    public int attachWaypointIndex = 1; // Waypoint index at which the cargo should be attached
    public int detachWaypointIndex = 3; // Waypoint index at which the cargo should be detached

    private int waypointIndex = 0;
    private bool isMoving = true;
    private float pauseTimer = 3f; // Time to pause at a waypoint

    void Update()
    {
        if (isMoving)
        {
            Move();
        }
        else
        {
            // Wait for a specified duration at the waypoint
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0f)
            {
                // Resume movement
                isMoving = true;
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                pauseTimer = 3f; // Reset the pause timer
            }
        }
    }

    private void Move()
    {
        // Move towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

        // Rotate towards the waypoint
        Vector3 direction = (waypoints[waypointIndex].position - transform.position).normalized;
        direction.y = 0; // Keep the rotation horizontal
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Check if the truck has reached the waypoint
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex == attachWaypointIndex)
            {
                cargoAttachment.AttachCargo();
            }
            else if (waypointIndex == detachWaypointIndex)
            {
                cargoAttachment.DetachCargo();
            }

            // Stop the truck at the waypoint
            isMoving = false;
        }
    }
}
