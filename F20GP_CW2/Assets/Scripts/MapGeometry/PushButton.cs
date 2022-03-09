using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPressed = false;

    //Retrieve the transforms of the push button geometry
    [SerializeField] private Transform buttonPlate;
    [SerializeField] private Transform buttonContainer;

    //Retrieve the piston maximum extended transform
    [SerializeField] private Transform maxExtention;
    //Retrieve the piston minimum extended transform
    [SerializeField] private Transform minExtention;

    //Retrieve the threshold to determine if the button is pressed
    [SerializeField] private float pressedThreshold;
    //Retrieve the pushback force of the button
    [SerializeField] private float pushbackForce = 30;

    private float currentButtonExtention;
    private float maxYPoisition;
    private float minYPoisition;

    void Start()
    {
        maxYPoisition = maxExtention.position.y;
        minYPoisition = minExtention.position.y;

        //Derive the collider arrays from the button plate and button container
        var buttonPlateColliders = buttonPlate.GetComponents<Collider>();
        var buttonContainerColliders = buttonContainer.GetComponents<Collider>();
        //Loop through all the colliders in each collider array
        foreach (Collider coll1 in buttonPlateColliders)
        {
            foreach (Collider coll2 in buttonContainerColliders)
            {
                //Ignore collisions between the push button and the button container
                Physics.IgnoreCollision(coll1, coll2);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Retrieve the current position of the push button
        currentButtonExtention = buttonPlate.transform.position.y;

        //Check if the button is in its default state
        if (currentButtonExtention >= maxYPoisition)
        {
            //Ensure that the button does not exceed its max position
            buttonPlate.position = new Vector3(buttonPlate.position.x, maxYPoisition, buttonPlate.position.z);
            //Set pressed state to false
            isPressed = false;
        }

        if (currentButtonExtention < minYPoisition)
        {
            //Ensure that the button does not exceed its minimum position
            buttonPlate.position = new Vector3(buttonPlate.position.x, minYPoisition, buttonPlate.position.z);
        }

        //If the button is below its default state apply force to push it back up
        if (currentButtonExtention < maxYPoisition)
        {
            //Apply a set force to the button to push it back up to the default state
            buttonPlate.GetComponent<Rigidbody>().AddForce(buttonPlate.transform.up * pushbackForce * Time.deltaTime);
        }

        //If the current position is within the threshold then set the button pressed state to true
        if (currentButtonExtention < (minYPoisition + pressedThreshold))
        {
            //Set the button state to true
            isPressed = true;
        }
    }
}
