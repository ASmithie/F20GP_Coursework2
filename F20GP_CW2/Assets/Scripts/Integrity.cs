using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integrity : MonoBehaviour
{
    public float integrity = 10f;
    public float integrityDecrease;
    public float force = 0.1f;
    public float gravity = 9.81f;
    public float tiltModifier = 1f;

    public Vector3 startUp;

    private void Start()
    {
        startUp = Vector3.up;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, startUp, Color.cyan, 5);
    }

    private void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float velocity = rb.velocity.magnitude;
        
        if(Vector3.Distance(startUp, Vector3.up) > 0.1f)
        {
            tiltModifier = Vector3.Distance(startUp, Vector3.up);
            Debug.Log(startUp);
            Debug.Log(Vector3.up);
            Debug.Log(Vector3.Distance(startUp, Vector3.up));
        }
        else 
        {
            tiltModifier = 1;
        }
        integrityDecrease = force * gravity * tiltModifier * Mathf.Abs(velocity);
        integrity-= integrityDecrease;
    }
}
