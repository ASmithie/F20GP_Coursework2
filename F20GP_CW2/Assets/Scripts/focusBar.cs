using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class focusBar : MonoBehaviour
{
    public static float maxFocus = 1f;
    public static float currentFocus = maxFocus;
    public static float rechargeFocus;
    public static float costFocus;

    // Start is called before the first frame update
    void Start()
    {   //how much should the fouc bar recharge
        rechargeFocus = 0.005f;
        //how much should it cost to use the spacebar
        costFocus = 0.05f;
        //recharge the focus bar every 0.1 seconds
        InvokeRepeating("RechargeBar", 0.0f, 0.1f);


    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void RechargeBar()
    {
        if (currentFocus < maxFocus)
        {
            currentFocus += rechargeFocus;
        }
    }
}
