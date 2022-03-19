using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public bool bossTrigger;
    // Start is called before the first frame update
    void Start()
    {
        bossTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            bossTrigger = true;
        }
    }
}
