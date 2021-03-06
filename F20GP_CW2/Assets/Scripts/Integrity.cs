using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integrity : MonoBehaviour
{
    public float integrity = 100f;
    public float integrityDecrease;
    public float force = 0.01f;
    public float gravity = 9.81f;
    public float tiltModifier = 1f;

    public bool useTilt = true; 

    [SerializeField] private float minimumDecrease = 1f;

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.up, Color.cyan, 5);
        Debug.DrawRay(transform.position, transform.up, Color.red, 2);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag("Boss"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            float velocity = rb.velocity.magnitude;
            if(velocity >= 1)
            {
                if (useTilt)
                {
                    if (Vector3.Distance(Vector3.up, transform.up) > 0.1f)
                    {
                        tiltModifier = Vector3.Distance(Vector3.up, transform.up);
                
            
                    }
                    else 
                    {
                        tiltModifier = 1;
                    }
                    integrityDecrease = force * gravity * tiltModifier * Mathf.Abs(velocity);
                }
                else
                {
                    integrityDecrease = force * gravity * Mathf.Abs(velocity);
                }

                //If the force exceeds a threshold decrease in force
                if (integrityDecrease > minimumDecrease)
                {
                    integrity -= integrityDecrease;
                }
                
            }
        }


        if (col.gameObject.CompareTag("Spike"))
        {
            //Spike negative health
            integrity -= 10f;
        }
    }
}
