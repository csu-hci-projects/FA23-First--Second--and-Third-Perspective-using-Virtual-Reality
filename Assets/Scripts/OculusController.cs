using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusController : MonoBehaviour
{
    public CraneController CraneController;
    Vector2 stickR;
    Vector2 stickL;
    bool isGrabOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //--- Right Controller
        stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);
        if (stickR.x != 0 || stickR.y != 0) { Debug.Log("Touch: Right Stick: " + stickR); }
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Debug.Log("Touch: A Button (Down)");
            if (isGrabOn)
            {
                CraneController.UnGrab();
                isGrabOn = false;
            }
            else
            {
                CraneController.Grab();
                isGrabOn = true;
            }
        }
        else if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            Debug.Log("Touch: A Button (Up)");
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Debug.Log("Touch: B Button (Down)");
        }
        else if (OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            Debug.Log("Touch: B Button (Up)");
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Debug.Log("Touch: Right Trigger (Down)");
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Debug.Log("Touch: Right Trigger (Up)");
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            Debug.Log("Touch: Right Grip (Down)");
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            Debug.Log("Touch: Right Grip (Up)");
        }

        //--- Left Controller
        stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
        if (stickL.x != 0 || stickL.y != 0) { Debug.Log("Touch: Left Stick: " + stickL); }
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: X Button (Down)");
        }
        else if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: X Button (Up)");
        }

        if (OVRInput.GetDown(OVRInput.Button.Start, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: Menu Button (Down)");
        }
        else if (OVRInput.GetUp(OVRInput.Button.Start, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: Menu Button (Up)");
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: Y Button (Down)");
        }
        else if (OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: Y Button (Up)");
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: Left Trigger (Down)");
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: Left Trigger (Up)");
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: Left Grip (Down)");
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            Debug.Log("Touch: Left Grip (Up)");
        }

        CraneController.MoveForwardBackward(stickL.y);
        CraneController.RotateLeftRight(stickL.x);
        CraneController.MoveUpDown(stickR.y);
        
    }
}
