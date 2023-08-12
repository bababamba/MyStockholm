using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QP_Quests : MonoBehaviour
{
    public Image buildingImg;
    public int sourcesNeeded;
    public int sourcesCollected;

    public bool isFinished = false; // 해당 건물은 만들어졌는가
    public bool bossReady;

    public GameObject connectedBuilding;

    void Update()
    {
        if(sourcesCollected == sourcesNeeded)
        {
            IsBuildingDone();
        }

        buildingImg.fillAmount = (float)sourcesCollected/sourcesNeeded;
    }


    void IsBuildingDone()
    {
        if(isFinished == false)
        {
            isFinished = true;
            connectedBuilding.SetActive(true);
        }
    }
}
