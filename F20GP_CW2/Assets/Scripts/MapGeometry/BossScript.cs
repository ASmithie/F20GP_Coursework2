using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] private Transform orbitPoint;
    [SerializeField] private float radius;
    [SerializeField] private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(orbitPoint.transform.position.x + radius, transform.position.y, orbitPoint.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(orbitPoint.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
    }
}
