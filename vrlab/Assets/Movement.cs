﻿using UnityEngine;
using Valve.VR;
public class Movement : MonoBehaviour
{
    private Vector2 touchpad;
    private float Direction;
    private Vector3 moveDirection;

    public float speed;
    public GameObject Head;
    public CapsuleCollider Collider;
    public GameObject AxisHand;//Hand Controller GameObject
    public float Deadzone;//the Deadzone of the trackpad. used to prevent unwanted walking.#

    public SteamVR_Action_Vector2 touchPadAction;
                        
    void Update()
    {
        //Set size and position of the capsule collider so it maches our head.
        Collider.height = Head.transform.localPosition.y;
        Collider.center = new Vector3(Head.transform.localPosition.x, Head.transform.localPosition.y / 2, Head.transform.localPosition.z);

        Vector3 newRotation = new Vector3(0, Head.transform.localRotation.y, 0);
        Debug.Log("euler angels: " + Head.transform.eulerAngles.y);
        GetComponent<Rigidbody>().transform.eulerAngles = newRotation;

        updateInput();
       if (GetComponent<Rigidbody>().velocity.magnitude < speed && touchpad.magnitude > Deadzone)
        {//make sure the touch isn't in the deadzone and we aren't going to fast.
         // moveDirection = Quaternion.AngleAxis(Angle(touchpad), Vector3.up) * Vector3.forward;//get the angle of the touch and correct it for the rotation of the controller
            moveDirection = new Vector3(touchpad.x, 0, touchpad.y);
            GetComponent<Rigidbody>().AddForce(moveDirection * 30);
       }
    }
    public static float Angle(Vector2 p_vector2)
    {
        if (p_vector2.x < 0)
        {
            return 360 - (Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg * -1);
        }
        else
        {
            return Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
        }
    }
    private void updateInput()
    {
        touchpad = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);
        Debug.Log("touchpad: " + touchpad);
    }
}