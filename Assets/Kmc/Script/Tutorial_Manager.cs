using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
    public int currentIndex = 0;
    public GameObject[] allPages;

    void Start()
    {
        Audio_Manager.Instance.BGM_Title();
    }

    public void NextPage()
    {
        Audio_Manager.Instance.SFX_ButtonClick();
        allPages[currentIndex].SetActive(false);
        currentIndex++;
        allPages[currentIndex].SetActive(true);
    }
}
