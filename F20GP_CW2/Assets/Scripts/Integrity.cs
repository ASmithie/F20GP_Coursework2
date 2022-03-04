using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integrity : MonoBehaviour
{
    public float integrity = 10f;

    public float integrityDecrease;

    public float force = 0f;
    public float gravity = 9.81f;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        integrityDecrease = force * gravity;
        integrity-= integrityDecrease;
    }
}
