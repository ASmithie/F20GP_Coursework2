using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    //Retrieve the spike open position
    [SerializeField] private Transform raisedPosition;
    //Retrieve the spike closed position
    [SerializeField] private Transform loweredPosition;

    //Retrieve spike cooldown
    [SerializeField] private float maxCooldown = 1;
    [SerializeField] private float minCooldown = 10;

    //Retrieve linear interpolation ratio
    [SerializeField] private float lerpRatio = 0.05f;

    //Retrieve tolerance before chaning direction
    [SerializeField] private float tolerance = 0.02f;

    private float spikeCooldown;

    private float startTime;
    private float currentTime;

    private bool lowered;

    private bool upwards;
    bool initialCount;

    private Vector3 rPosition;
    private Vector3 lPosition;
    private Vector3 endPosition;



    void Start()
    {
        lPosition = loweredPosition.localPosition;
        rPosition = raisedPosition.localPosition;

        spikeCooldown = Random.Range(minCooldown, maxCooldown);

        //Set the local position of the spike to the closed position on startup
        transform.localPosition = rPosition;


        endPosition = lPosition;
        //Do not raise the spikes on startup
        upwards = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (lowered)
        {
            if (initialCount)
            {
                startTime = Time.time;
                initialCount = false;
            }

            currentTime = Time.time;

            float timeDifference = currentTime - startTime;

            if (spikeCooldown <= timeDifference)
            {
                lowered = false;
            }
            Debug.Log(("Current position %f", timeDifference));
            //ADD PARTICLE EFFECT JUST BEFORE IT RAISES
        }
        if (!lowered)
        {


            //If the spike is to be raised
            if (upwards)
            {
                //Debug.Log("raise");
                //The final position is the open position
                endPosition = rPosition;

                //Check if the current position is not the end position
                if (transform.localPosition.y < endPosition.y - tolerance)
                {
                    //Move the spike towards the end position
                    moveSpike(endPosition);
                }
                else upwards = false;
            }
            //If the spike is to be closed
            if (!upwards)
            {
                //Debug.Log("lower");
                //The final position is the closed position
                endPosition = lPosition;

                //Check if the current position is not the end position
                if (transform.localPosition.y > endPosition.y + tolerance)
                {
                    //Move the spike towards the end position
                    moveSpike(endPosition);
                }
                else
                {
                    Debug.Log("lowered");
                    upwards = true;
                    lowered = true;
                    initialCount = true;
                    return;
                }
            }
        }

    }

    void moveSpike(Vector3 endPosition)
    {
        //Linearly interpolate the position of the spike towards the end position
        transform.localPosition = Vector3.Lerp(transform.localPosition, endPosition, lerpRatio);
    }

}
