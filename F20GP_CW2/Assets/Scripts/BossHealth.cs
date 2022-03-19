using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public float health = 100;


    private void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("player hit");
        }
    }
}
