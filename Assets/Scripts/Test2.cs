using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private bool keyIsHeldDown = false;
    private float cooldown = 1f; // Adjust this value to set the cooldown duration
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            keyIsHeldDown = true;

            // Check if enough time has passed since the last function call
            if (Time.time - timer > cooldown)
            {
                // Call your function here
                YourFunction();

                // Update the timer
                timer = Time.time;
            }
        }
        else
        {
            keyIsHeldDown = false;
        }
    }
    void YourFunction()
    {
        print("function");
    }
}
