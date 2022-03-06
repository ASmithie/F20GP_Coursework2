using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integrity : MonoBehaviour
{
    public float integrity = 10f;
    public float integrityDecrease;
    public float force = 0.1f;
    public float gravity = 9.81f;

    private void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float velocity = rb.velocity.magnitude;
        integrityDecrease = force * gravity * Mathf.Abs(velocity);
        integrity-= integrityDecrease;
    }
}
