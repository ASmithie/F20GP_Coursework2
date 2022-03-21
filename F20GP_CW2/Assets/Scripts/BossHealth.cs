using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public float health = 100;
    public bool bossDead = false;


    private void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("boss hit");
            health -= 10;

            if (health <= 0)
            {
                bossDead = true;
            }
        }
    }
}
