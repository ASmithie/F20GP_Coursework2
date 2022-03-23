using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagement : MonoBehaviour
{

    public float timer = 0;
    Text txt;
    public GameObject isUIOn;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Time:" + timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(isUIOn.activeInHierarchy)
        {
            timer += Time.deltaTime;
            txt.text = "Time: " + Mathf.RoundToInt(timer);

        }
    }
}
