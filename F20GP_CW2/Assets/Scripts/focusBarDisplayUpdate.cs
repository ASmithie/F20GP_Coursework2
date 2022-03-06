using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class focusBarDisplayUpdate : MonoBehaviour
{
    private static Image focusBarImage;
    // Start is called before the first frame update
    void Start()
    {
        focusBarImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        focusBarImage.fillAmount = focusBar.currentFocus;
    }
}
