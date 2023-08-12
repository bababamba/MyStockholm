using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
    public int currentIndex = 0;
    public GameObject[] allPages;

    public void NextPage()
    {
        allPages[currentIndex].SetActive(false);
        currentIndex++;
        allPages[currentIndex].SetActive(true);
    }
}
