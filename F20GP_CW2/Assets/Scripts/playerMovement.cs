using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController playerController;
    Rigidbody rb;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //change these values to affect the size of player movement
    [SerializeField] private float speed = 12f;
    [SerializeField] private float jumpHeight = 12f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //calculate vextor with player inputs
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        //is there player input?
        if(direction.magnitude >= 0.1f)
        {
            
            //Calculate the velocity vector based on the local direction of the camera
            Vector3 velocity = cam.transform.right * horizontal + FlatForwardVector(cam.transform.forward) * vertical;
            Vector3 forcePosition = transform.position;

            //Add the velocity to the players movement
            //Force is added to different parts of the player object depending on which direction the player is going
            //This will cause the player object to rotate while moving


            rb.AddForce(velocity * speed);

            /*
             
            if (direction.z > 0)
            {
                forcePosition.z += GetComponent<Collider>().bounds.size.z;
                rb.AddForceAtPosition(velocity * speed, forcePosition);

            }
            if (direction.x < 0)
            {
                forcePosition.x -= GetComponent<Collider>().bounds.size.x;
                rb.AddForceAtPosition(velocity * speed, forcePosition);
            }
            if (direction.z < 0)
            {
                forcePosition.z -= GetComponent<Collider>().bounds.size.z;
                rb.AddForceAtPosition(velocity * speed, forcePosition);
            }
            if (direction.x > 0)
            {
                forcePosition.x += GetComponent<Collider>().bounds.size.x;
                rb.AddForceAtPosition(velocity * speed, forcePosition);
            }
            */

        }
        //check if the player wants to jump and is there budget in the focus bar to do so
        if (Input.GetKeyDown("space") && focusBar.currentFocus > focusBar.costFocus)
        {
            //remove some focus
            focusBar.currentFocus -= focusBar.costFocus;
            //add force upwards to the player object
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }
    }

    private Vector3 FlatForwardVector(Vector3 forwardVector)
    {
        //Determine the flat forward vector of a transform by ignoring rotation
        Vector3 flatForwardView = new Vector3(forwardVector.x, 0, forwardVector.z);
        flatForwardView.Normalize();
        return flatForwardView;
    }
}
