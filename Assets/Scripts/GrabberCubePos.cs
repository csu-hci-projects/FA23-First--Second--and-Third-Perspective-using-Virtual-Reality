using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberCubePos : MonoBehaviour
{
    public GameObject GrabberCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward=-GrabberCube.transform.forward;
    }
}
