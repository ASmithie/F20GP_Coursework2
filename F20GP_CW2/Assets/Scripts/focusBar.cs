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
    {
        rechargeFocus = 0.005f;
        costFocus = 0.05f;
        InvokeRepeating("RechargeBar", 0.0f, 0.1f);


    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void RechargeBar()
    {
        currentFocus += rechargeFocus;
    }
}
