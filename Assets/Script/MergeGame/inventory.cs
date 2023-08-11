using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class inventory : MonoBehaviour
{
    public static bool invectoryActivated = false;  // 인벤토리 활성화 여부. true가 되면 카메라 움직임과 다른 입력을 막을 것이다.

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting 
    [SerializeField]
    private GameObject go_NPCParent;
    [SerializeField]
    private GameObject NPCPrefab;  


    [SerializeField]
    private Sprite[] itemImage;
    [SerializeField]
    private int itemTypes = 3;
    [SerializeField]
    private slot[] slots;  // 슬롯들 배열

    private NPCController controller;
    int numberOfNPC = 20;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<slot>();
        controller = go_NPCParent.GetComponent<NPCController>();
        slots[5].AddItem(100);
        //gameObject.SetActive(false);
        GameObject nPC = Instantiate(NPCPrefab, new Vector3(-301.7f, 676.7f, 0f), Quaternion.identity);
        nPC.transform.SetParent(go_NPCParent.transform, false);
        nPC.GetComponent<NPC>().init(2,1,10);
        for (int i = 0; i < 2; i++)
        {
            GameObject nPCi = Instantiate(NPCPrefab, new Vector3(-301.7f + 297*(i+1), 676.7f, 0f), Quaternion.identity);
            nPCi.transform.SetParent( go_NPCParent.transform,false);
            nPCi.GetComponent<NPC>().init(2, 1, 10);
        }
        for (int i = 0; i < numberOfNPC; i++)
        {
            GameObject nPCi = Instantiate(NPCPrefab, new Vector3(-301.7f + 297 *4, 676.7f, 0f), Quaternion.identity);
            nPCi.transform.SetParent(go_NPCParent.transform, false);
            nPCi.GetComponent<NPC>().init(2, 1, 10);
        }
        controller.init();
    }
    
    public void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    public void CloseInventory()
    {
       
        go_InventoryBase.SetActive(false);
    }
    
    public void AcquireItem(int _item, int _count = 1)
    {List<int> tempList = new List<int>();

        for (int i = 0; i < slots.Length; i++)//랜덤한 빈 위치에 아이템 떨구기
        {
            if (slots[i].itemType == 0)
            {
                tempList.Add(i);
            }
        }
        if (tempList.Count > 0)
        {
            int random = Random.Range(0, tempList.Count);
            slots[tempList[random]].AddItem(1);
        }
        else
            Debug.Log("판이 꽉찼습니다!");
    }
    public Sprite getImageOfItem(int _type, int _level)
    {if(_type == 100)
            return itemImage[0];
    else
        return itemImage[(_type - 1) * itemTypes + _level];
    }

}