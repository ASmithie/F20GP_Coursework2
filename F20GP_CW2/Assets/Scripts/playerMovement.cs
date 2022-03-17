using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController playerController;
   
    public Transform cam;
    
    [SerializeField] private float speed = 12f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    [SerializeField]  private float jumpHeight;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if(direction.magnitude >= 0.1f /*&& focusBar.currentFocus > focusBar.costFocus*/)
        {
            //focusBar.currentFocus -= focusBar.costFocus;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            

            //Calculate the velocity vector based on the local direction of the camera
            Vector3 velocity = cam.transform.right * horizontal + FlatForwardVector(cam.transform.forward) * vertical;
            Vector3 forcePosition = transform.position;
            //Add the velocity to the players movement
            if (direction.z > 0)
            {
                forcePosition.z += 1;
                rb.AddForceAtPosition(velocity * speed, forcePosition);

            }
            if (direction.x < 0)
            {
                forcePosition.x -= 1;
                rb.AddForceAtPosition(velocity * speed, forcePosition);
            }
            if (direction.z < 0)
            {
                forcePosition.z -= 1;
                rb.AddForceAtPosition(velocity * speed, forcePosition);
            }
            if (direction.x > 0)
            {
                forcePosition.x += 1;
                rb.AddForceAtPosition(velocity * speed, forcePosition);
            }
            

        }

        if (Input.GetKeyDown("space"))
        {
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
