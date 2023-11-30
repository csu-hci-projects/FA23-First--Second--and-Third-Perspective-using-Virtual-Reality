using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class WaypointCargo
{
    public Transform waypoint;
    public List<GameObject> cargoPrefabs; // List of cargo prefabs for this waypoint
    public int nextCargoIndex = 0; // Index to track the next cargo to be attached
}

public class TruckController : MonoBehaviour
{
    public Transform[] waypoints;
    public float[] truckWaypointRotations; // Rotation angles for the truck at each waypoint
    public float[] cargoWaypointRotations; // X-axis rotation angles for the cargo at each waypoint
    public float[] waitTimes; // Wait times in seconds for each waypoint
    public Transform cargoAttachmentPoint; // Attachment point for the cargo on the truck
    public int[] attachCargoWaypoints; // Waypoints where cargo will be attached
    public int[] detachCargoWaypoints; // Waypoints where cargo will be detached
    public List<WaypointCargo> waypointCargos; // List of waypoint cargo configurations

    private GameObject currentCargo; // Current cargo instance
    public float speed = 5f;

    private int waypointIndex = 0;
    private bool isMoving = true;
    private int waypointVisitCount = 0; // Count of visits to the current waypoint

    void Start()
    {
        AttachDetachCargo();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0; // Reset to the first waypoint if all have been visited
        }

        Transform targetWaypoint = waypoints[waypointIndex];

        if (truckWaypointRotations != null && truckWaypointRotations.Length > waypointIndex)
        {
            RotateTowards(truckWaypointRotations[waypointIndex], cargoWaypointRotations[waypointIndex]);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            if (!isMoving)
            {
                return; // Prevents reattaching cargo if already waiting at the waypoint
            }

            isMoving = false;
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        AttachDetachCargo();

        float waitTime = (waitTimes != null && waitTimes.Length > waypointIndex) ? waitTimes[waypointIndex] : 0f;
        yield return new WaitForSeconds(waitTime);

        waypointVisitCount++;

        if (waypointVisitCount >= 10)
        {
            waypointVisitCount = 0; // Reset the visit count for the next waypoint
            waypointIndex++; // Increment to next waypoint
        }

        isMoving = true; // Resume moving to the next waypoint or revisiting the current one
    }

    void AttachDetachCargo()
    {
        if (attachCargoWaypoints.Contains(waypointIndex) && currentCargo == null) // Only attach if there's no current cargo
        {
            AttachCargo();
        }
        if (detachCargoWaypoints.Contains(waypointIndex))
        {
            DetachCargo();
            ResetCargoAttachmentsAtWaypoint(waypoints[waypointIndex]); // Reset attachment status when detaching cargo
        }
    }

    void RotateTowards(float truckYRotation, float cargoXRotation)
    {
        Vector3 truckRotation = new Vector3(0, truckYRotation, 90);
        transform.rotation = Quaternion.Euler(truckRotation);

        if (currentCargo != null)
        {
            Vector3 cargoRotation = currentCargo.transform.localEulerAngles;
            cargoRotation.x = cargoXRotation;
            currentCargo.transform.localEulerAngles = cargoRotation;
        }
    }

    void AttachCargo()
    {
        foreach (var waypointCargo in waypointCargos)
        {
            if (waypointCargo.waypoint == waypoints[waypointIndex] &&
                waypointCargo.nextCargoIndex < waypointCargo.cargoPrefabs.Count)
            {
                GameObject nextCargoPrefab = waypointCargo.cargoPrefabs[waypointCargo.nextCargoIndex];
                currentCargo = Instantiate(nextCargoPrefab, cargoAttachmentPoint.position, Quaternion.identity);
                currentCargo.transform.SetParent(cargoAttachmentPoint);
                currentCargo.transform.localPosition = Vector3.zero;
                currentCargo.transform.localRotation = Quaternion.identity;

                waypointCargo.nextCargoIndex++; // Increment to the next cargo for the next visit
                break; // Attach one cargo per visit
            }
        }
    }

    void DetachCargo()
    {
        if (currentCargo != null)
        {
            currentCargo.transform.SetParent(null);
            currentCargo.transform.eulerAngles = new Vector3(0, 90, currentCargo.transform.eulerAngles.z);
            currentCargo = null; // Clear the current cargo
        }
    }

    void ResetCargoAttachmentsAtWaypoint(Transform waypoint)
    {
        foreach (var waypointCargo in waypointCargos)
        {
            if (waypointCargo.waypoint == waypoint)
            {
                waypointCargo.nextCargoIndex = 0; // Reset the index for this waypoint
            }
        }
    }
}
