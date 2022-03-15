using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integrity : MonoBehaviour
{
    public float integrity = 10f;
    public float integrityDecrease;
    public float force = 0.01f;
    public float gravity = 9.81f;
    public float tiltModifier = 1f;

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.up, Color.cyan, 5);
        Debug.DrawRay(transform.position, transform.up, Color.red, 2);
    }

    private void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float velocity = rb.velocity.magnitude;

        Debug.Log(Vector3.up);
        Debug.Log(transform.up);
        Debug.Log(Vector3.Distance(Vector3.up, transform.up));

        if (Vector3.Distance(Vector3.up, transform.up) > 0.1f)
        {
            tiltModifier = Vector3.Distance(Vector3.up, transform.up);
            Debug.Log("---------------------------------hit------------------------------");
            
        }
        else 
        {
            tiltModifier = 1;
        }
        integrityDecrease = force * gravity * tiltModifier * Mathf.Abs(velocity);
        integrity-= integrityDecrease;
    }
}
