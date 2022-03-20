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
    private static Image bossBarImage;

    private GameObject playerObject;
    private Integrity playerIntegrity;

    private BossHealth bossIntegrity;

    public Text bossNameField;
    public Text level;

    public GameObject characterSelectionUI;
    public GameObject pauseMenuUI;
    public GameObject mainUI;

    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        bossName = " ";
        focusBarImage = GameObject.Find("focusBar").GetComponent<Image>();
        healthBarImage = GameObject.Find("healthBar").GetComponent<Image>();
        bossBarImage = GameObject.Find("bossHealth").GetComponent<Image>();

        playerObject = characterSelection.selectedChar;
        playerIntegrity = playerObject.transform.GetChild(0).GetComponent<Integrity>();

        bossIntegrity = boss.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossActive)
        {
            bossNameField.text = bossName;
            bossBarImage.fillAmount = bossIntegrity.health / 100;
        }
        else
        {
            bossNameField.text = "No boss name";

        }

        focusBarImage.fillAmount = focusBar.currentFocus;

        healthBarImage.fillAmount = playerIntegrity.integrity / 10;

    }
}
