using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GatePhysicsPuzzle: MonoBehaviour
{
    //Retrieve the button which controlls the gate
    [SerializeField] private PushButton buttonController;
    //Retrieve the gate open position
    [SerializeField] private Vector3 openPosition;
    //Retrieve the gate closed position
    [SerializeField] private Vector3 closePosition;
    //Retrieve the linear interpoalation ratio for the closing and opening of the gate
    [SerializeField] private float lerpRadtio = 0.03f;

    //Declare local variables
    private Vector3 endPosition;
    private bool prevButtonState = false;
    private bool raiseGate;

    void Start()
    {
        //Set the local position of the gate to the closed position on startup
        transform.localPosition = closePosition;
        endPosition = closePosition;
        //Do not raise the gate ons startup
        raiseGate = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Ensure that the button only executes a single time
        if (buttonController.isPressed) raiseGate = true;
        else raiseGate = false;

        //If the gate is to be raised
        if (raiseGate)
        {
            //The final position is the open position
            endPosition = openPosition;
        }
        //If the gate is to be closed
        if (!raiseGate)
        {
            //The final position is the closed position
            endPosition = closePosition;
        }

        //Check if the current position is not the end position
        if (transform.localPosition != endPosition)
        {
            //Move the gate towards the end position
            moveGate(endPosition);
        }
        //Set the previous state of the button
        prevButtonState = buttonController.isPressed;
    }

    void moveGate(Vector3 endPosition)
    {
        //Linearly interpolate the position of the gate towards the end position
        transform.localPosition = Vector3.Lerp(transform.localPosition, endPosition, lerpRadtio);
    }



}
