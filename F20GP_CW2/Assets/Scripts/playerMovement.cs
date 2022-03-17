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

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if(direction.magnitude >= 0.1f /*&& focusBar.currentFocus > focusBar.costFocus*/)
        {
            //focusBar.currentFocus -= focusBar.costFocus;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb = GetComponent<Rigidbody>();
            //rb.AddForce(moveDir * speed);

            //Calculate the velocity vector based on the local direction of the camera
            Vector3 velocity = cam.transform.right * horizontal + FlatForwardVector(cam.transform.forward) * vertical;
            //Add the velocity to the players movement
            rb.AddForce(velocity * speed);

            //playerController.Move(moveDir * speed * Time.deltaTime);

        }

        //original attempt at camera and player movement, causes player to violently fly away from centre when interacting with gravity
        /*float angle = cam.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        if (Input.GetKeyDown("space") && focusBar.currentFocus >= focusBar.costFocus)
        {
            
            

            focusBar.currentFocus -= focusBar.costFocus;
            Vector3 direction = cam.forward;

            playerController.Move(direction * speed * Time.deltaTime);


        }*/
    }

    private Vector3 FlatForwardVector(Vector3 forwardVector)
    {
        //Determine the flat forward vector of a transform by ignoring rotation
        Vector3 flatForwardView = new Vector3(forwardVector.x, 0, forwardVector.z);
        flatForwardView.Normalize();
        return flatForwardView;
    }
}
