using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QP_Quests : MonoBehaviour
{
    [SerializeField] GameObject[] pieces;
    [SerializeField] int bossStageLevel;
    [SerializeField] GameObject invItem;
    [SerializeField] bool isAllPieceCollected = false;
    [SerializeField] Transform mainCanvas;
    [SerializeField] GameObject BossObj;

    [SerializeField] GameObject middleTutorial;

    void Update()
    {
        isAllPieceCollected = true; // 초기값을 true로 설정

        for (int i = 0; i < pieces.Length; i++)
        {
            if (!pieces[i].activeSelf)
            {
                isAllPieceCollected = false;
                break;
            }

            Main_Manager.Instance.showMiddleTutorial();

        }
    }

    public void OnClickWhilEverythingisDOne()
    {
        if (isAllPieceCollected)
        {
            GameObject obj = Instantiate(BossObj, mainCanvas);
            obj.GetComponent<inventoryExtream>().BossInit(bossStageLevel);
        }
    }

    public void CloseMIddleTutorial()
    {
        middleTutorial.SetActive(false);
    }
}
