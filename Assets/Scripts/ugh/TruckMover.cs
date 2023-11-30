using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMover : MonoBehaviour
{
    public Transform[] waypoints;
    public float[] waypointAngles; // Array of angles for each waypoint
    public float speed = 5f;

    private int waypointIndex = 0;
    private float minDistance = 0.1f;

    void Start()
    {
        // Ensure waypointAngles array is the same length as waypoints array
        if (waypointAngles.Length != waypoints.Length)
        {
            Debug.LogWarning("Waypoint angles array length does not match waypoints array length. Please adjust in the Inspector.");
            waypointAngles = new float[waypoints.Length];
        }
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 targetPosition = new Vector3(waypoints[waypointIndex].position.x, transform.position.y, waypoints[waypointIndex].position.z);

        if (Vector3.Distance(transform.position, targetPosition) > minDistance)
        {
            // Move the truck towards the waypoint
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            // Snap to the rotation angle specified for the waypoint
            transform.rotation = Quaternion.Euler(0, waypointAngles[waypointIndex], 0);

            // Move to the next waypoint
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }
}
