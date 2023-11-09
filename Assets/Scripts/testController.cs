using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testController : MonoBehaviour
{
    public CraneController CraneController;
    public float stickUp;
    public float stickDown;
    public float stick2Up;
    public float stick2Down;
    public float stickLeft;
    public float stickRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CraneController.MoveForwardBackward(stickUp);
        }
        if (Input.GetKey(KeyCode.S))
        {
            CraneController.MoveForwardBackward(stickDown);
        }

        if (Input.GetKey(KeyCode.A))
        {
            CraneController.MoveUpDown(stick2Up);
        }
        if (Input.GetKey(KeyCode.D))
        {
            CraneController.MoveUpDown(stick2Down);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            CraneController.RotateLeftRight(stickLeft);
        }
        if (Input.GetKey(KeyCode.E))
        {
            CraneController.RotateLeftRight(stickRight);
        }
    }
}
