using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public float health = 150;
    public bool bossDead = false;
    public float healthDecrease;

    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("boss hit");
            healthDecrease = col.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            health -= healthDecrease;
            Debug.Log(health);
            Debug.Log(healthDecrease);
            if (health <= 0)
            {
                bossDead = true;
            }
        }
    }
}
