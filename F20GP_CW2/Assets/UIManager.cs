using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public bool bossActive;
    public string bossName;

    private static Image focusBarImage;
    private static Image healthBarImage;

    private GameObject playerObject;
    private Integrity playerIntegrity;

    public Text bossNameField;
    public Text level;

    // Start is called before the first frame update
    void Start()
    {
        bossName = "";
        focusBarImage = GameObject.Find("focusBar").GetComponent<Image>();
        healthBarImage = GameObject.Find("healthBar").GetComponent<Image>();
        playerObject = GameObject.Find("Sword02_LowPoly (1)");
        playerIntegrity = playerObject.GetComponent<Integrity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossActive)
        {
            bossNameField.text = bossName;

        }
        else
        {
            bossNameField.text = "";

        }

        focusBarImage.fillAmount = focusBar.currentFocus;

        healthBarImage.fillAmount = playerIntegrity.integrity / 10;

    }
}
