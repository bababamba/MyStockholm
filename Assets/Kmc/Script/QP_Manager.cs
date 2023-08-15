using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QP_Manager : MonoBehaviour
{
    public static QP_Manager Instance;
    public GameObject[] allPieces;
    public GameObject questOBJ;

    public GameObject BossItem1;
    public GameObject BossItem2;
    public GameObject BossItem3;
    public GameObject BossItem4;
    public GameObject BossItem5;
    public GameObject BossItem6;

    void Awake()
    {
        questOBJ.SetActive(true);
        Instance = this;
    }

    void Start()
    {
        questOBJ.SetActive(false);
    }

    public void GetPiece(int _index)
    {
        Debug.Log(_index);
        Debug.Log(_index + " 칸이 켜짐" + allPieces[_index].name);
        allPieces[_index].SetActive(true);

    }

    public void TurnItem(int _index)
    {
        _index++;
        Debug.Log(_index + " 를 키려고 함");
        switch (_index)
        {

            case 1: BossItem1.SetActive(true); break;
            case 2: BossItem2.SetActive(true); break;
            case 3: BossItem3.SetActive(true); break;
            case 4: BossItem4.SetActive(true); break;
            case 5: BossItem5.SetActive(true); break;
            case 6: BossItem6.SetActive(true); break;

        }
    }
}
