using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    //Retrieve the transforms of the spike geometry
    [SerializeField] private Transform thisObject;
    [SerializeField] private Transform parentObject;

    //Retrieve the spike open position
    [SerializeField] private Transform raisedPosition;
    //Retrieve the spike closed position
    [SerializeField] private Transform loweredPosition;

    //Retrieve spike cooldown
    [SerializeField] private float maxCooldown = 5;
    [SerializeField] private float minCooldown = 10;

    //Retrieve linear interpolation ratio
    [SerializeField] private float lerpRatio = 0.05f;

    //Retrieve tolerance before chaning direction
    [SerializeField] private float tolerance = 0.02f;

    //Retrieve tolerance before chaning direction
    [SerializeField] private ParticleSystem playerWarning;

    //Retrieve tolerance before chaning direction
    [SerializeField] private float playerWarningCooldown = 3f;

    private float spikeCooldown;

    private float startTime;
    private float currentTime;

    private bool lowered;

    private bool upwards;
    bool initialCount;

    private Vector3 rPosition;
    private Vector3 lPosition;
    private Vector3 endPosition;

    private bool warningPlaying;


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

        playerWarning.Stop();

        //Ignore collisions between the turning rigid bodies and the obstacles in the map
        Physics.IgnoreLayerCollision(7, 7);
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(6, 6);

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

            if ((spikeCooldown - playerWarningCooldown) <= timeDifference && !warningPlaying)
            {
                //Debug.Log("Playing particles");
                //Debug.Log(timeDifference);
                //Debug.Log(spikeCooldown);
                warningPlaying = true;
                playerWarning.Play();
            }

            if (spikeCooldown <= timeDifference)
            {
                playerWarning.Stop();
                lowered = false;
                warningPlaying = false;
            }


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
                    //Debug.Log("lowered");
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
