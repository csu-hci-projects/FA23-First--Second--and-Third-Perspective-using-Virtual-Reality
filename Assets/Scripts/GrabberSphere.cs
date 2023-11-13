using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberSphere : MonoBehaviour
{
    private Renderer renderer;
    private Color originalColor;
    void Start()
    {
        // Get the Renderer component
        renderer = GetComponent<Renderer>();

        // Store the original color
        originalColor = renderer.material.color;
    }
    void ChangeColor(Color newColor)
    {
        // Set the color of the material
        renderer.material.color = newColor;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grabbable"))
        {
            ChangeColor(Color.green);
            GetComponentInParent<CraneController>().GrabberSphereOnTriggerEnter(other);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Grabbable"))
        {
            ChangeColor(originalColor);
            GetComponentInParent<CraneController>().GrabberSphereOnTriggerExit(other);
        }
    }
}
