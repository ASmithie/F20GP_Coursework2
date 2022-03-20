using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class UIManager : MonoBehaviour
{
    //game ui
    public string bossName;

    private static Image focusBarImage;
    private static Image healthBarImage;
    private static Image bossBarImage;

    private Integrity playerIntegrity;

    private BossHealth bossIntegrity;

    public Text bossNameField;
    public Text level;

    public GameObject boss;

    [SerializeField] private BossTrigger trigger;

    //ui panels
    public GameObject MainMenuUI;
    public GameObject InstructionsUI;
    public GameObject GameUI;
    public GameObject PauseUI;
    public GameObject BossUI;
    public GameObject GameOverUI;
    public GameObject CharacterSelectionUI;

    //character selector
    public Transform characters;
    private GameObject[] characterList;
    private int characterIndex;
    public GameObject thirdpersoncamera;
    public CinemachineFreeLook vcam;
    public static GameObject selectedChar;

    //pause menu
    public static bool isPaused = false;

    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuUI.SetActive(true);
        InstructionsUI.SetActive(true);
        GameUI.SetActive(true);
        PauseUI.SetActive(true);
        BossUI.SetActive(true);
        GameOverUI.SetActive(true);
        CharacterSelectionUI.SetActive(true);

        //game ui setup
        focusBarImage = GameObject.Find("focusBar").GetComponent<Image>();
        healthBarImage = GameObject.Find("healthBar").GetComponent<Image>();
        bossBarImage = GameObject.Find("bossHealth").GetComponent<Image>();
        bossIntegrity = boss.GetComponent<BossHealth>();
        
        //character selector setup
        characterList = new GameObject[characters.childCount];
        for(int i = 0;i < characters.childCount; i++)
        {
            characterList[i] = characters.GetChild(i).gameObject;
            characterList[i].SetActive(false);
        }
        characterList[0].SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        gameOver = false;

        //ui panel setup
        MainMenuUI.SetActive(true);
        InstructionsUI.SetActive(false);
        GameUI.SetActive(false);
        PauseUI.SetActive(false);
        BossUI.SetActive(false);
        GameOverUI.SetActive(false);
        CharacterSelectionUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameOver)
        {

            if (trigger.bossTrigger)
            {
                BossUI.SetActive(true);
                bossNameField.text = bossName;
                bossBarImage.fillAmount = bossIntegrity.health / 100;
            }
            else
            {
                BossUI.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Escape) && !CharacterSelectionUI.active)
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            if (GameUI.active)
            {
                playerIntegrity = selectedChar.transform.GetChild(0).GetComponent<Integrity>();
                focusBarImage.fillAmount = focusBar.currentFocus;
                healthBarImage.fillAmount = playerIntegrity.integrity / 10;

                if (playerIntegrity.integrity <= 0)
                {
                    gameOver = true;
                    GameUI.SetActive(false);
                    BossUI.SetActive(false);
                    GameOverUI.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
            }

        }
        
        

    }

    //main menu methods
    public void MainMenuPlay()
    {
        MainMenuUI.SetActive(false);
        CharacterSelectionUI.SetActive(true);
    }

    public void MainMenuInstructions()
    {
        MainMenuUI.SetActive(false);
        InstructionsUI.SetActive(true);
    }

    //character selector methods
    public void selectLeft()
    {
        characterList[characterIndex].SetActive(false);
        characterIndex--;
        if (characterIndex < 0)
        {
            characterIndex = characterList.Length - 1;
        }
        characterList[characterIndex].SetActive(true);

    }

    public void selectRight()
    {
        characterList[characterIndex].SetActive(false);
        characterIndex++;
        if (characterIndex == characterList.Length)
        {
            characterIndex = 0;
        }
        characterList[characterIndex].SetActive(true);
    }

    public void confirm()
    {
        vcam.Follow = characterList[characterIndex].transform.GetChild(0);
        vcam.LookAt = characterList[characterIndex].transform.GetChild(0);
        selectedChar = characterList[characterIndex];
        playerMovement script = characterList[characterIndex].transform.GetChild(0).GetComponent<playerMovement>();
        script.enabled = true;
        GameUI.SetActive(true);
        CharacterSelectionUI.SetActive(false);
        thirdpersoncamera.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    //pause menu methods
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        PauseUI.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameUI.SetActive(false);
        BossUI.SetActive(false);
    }

}
