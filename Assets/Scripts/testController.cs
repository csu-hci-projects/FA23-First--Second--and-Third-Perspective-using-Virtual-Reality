using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testController : MonoBehaviour
{
    public CraneController CraneController;
    public RopeControllerRealistic RopeController;
    public float stickUp;
    public float stickDown;
    public float stick2Up;
    public float stick2Down;
    public float stickLeft;
    public float stickRight;
    private bool keyIsHeldDown = false;
    private bool keyIsHeldDown2 = false;
    private float cooldown = 1f; // Adjust this value to set the cooldown duration
    private float timer = 0f;
    private float timer2 = 0f;
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
            keyIsHeldDown = true;

            // Check if enough time has passed since the last function call
            if (Time.time - timer > cooldown)
            {
                // Call your function here
                RopeController.DecreaseRopeLength(1);

                // Update the timer
                timer = Time.time;
            }
        }
        else
        {
            keyIsHeldDown = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            keyIsHeldDown2 = true;

            // Check if enough time has passed since the last function call
            if (Time.time - timer2 > cooldown)
            {
                // Call your function here
                RopeController.IncreaseRopeLength(1);

                // Update the timer
                timer2 = Time.time;
            }
        }
        else
        {
            keyIsHeldDown2 = false;
        }
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            //CraneController.MoveUpDown(stick2Up);
            RopeController.DecreaseRopeLength(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //CraneController.MoveUpDown(stick2Down);
            RopeController.IncreaseRopeLength(1);
        }*/

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
