using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class characterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int characterIndex;
    public GameObject thirdpersoncamera;
    public CinemachineFreeLook vcam;

    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        characterList = new GameObject[transform.childCount];
        for(int i = 0;i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
            characterList[i].SetActive(false);
        }
        characterList[0].SetActive(true);


    }

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
        playerMovement script = characterList[characterIndex].transform.GetChild(0).GetComponent<playerMovement>();
        script.enabled = true;
        thirdpersoncamera.SetActive(true);
        canvas.SetActive(false);
    }
}
