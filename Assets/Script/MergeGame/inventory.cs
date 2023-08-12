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


    public TextAsset csvFile;
    public GameObject moneyTarget;
    
    public GameObject bluePTarget;


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
        List<List<int>> questPool = ReadCSV(csvFile);
        slots = go_SlotsParent.GetComponentsInChildren<slot>();
        controller = go_NPCParent.GetComponent<NPCController>();
        slots[5].AddItem(100);
        //gameObject.SetActive(false);
        GameObject nPC = Instantiate(NPCPrefab, new Vector3(-301.7f, 676.7f, 0f), Quaternion.identity);
        nPC.transform.SetParent(go_NPCParent.transform, false);
        nPC.GetComponent<NPC>().init(questPool[0][0], questPool[0][1], questPool[0][2] , questPool[0][3], 1);
        nPC.GetComponent<NPC>().face.sprite = controller.getNPCFace(1);
        for (int i = 0; i < 2; i++)
        {
            GameObject nPCi = Instantiate(NPCPrefab, new Vector3(-301.7f + 297*(i+1), 676.7f, 0f), Quaternion.identity);
            nPCi.transform.SetParent( go_NPCParent.transform,false);
            nPCi.GetComponent<NPC>().init(questPool[i + 1][0], questPool[i + 1][1], questPool[i + 1][2], questPool[i + 1][3], 1);
            nPCi.GetComponent<NPC>().face.sprite = controller.getNPCFace(1);
        }
        instantiateFromPool(questPool);
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
    private List<List<int>> ReadCSV(TextAsset file)
    {
        List<List<int>> data = new List<List<int>>();

        string[] lines = file.text.Split('\n');
        foreach (string line in lines)
        {
            Debug.Log(line);
            string[] values = line.Split(',');
            
            List<int> row = new List<int>();

            foreach (string value in values)
            {
                int intValue;
                if (int.TryParse(value, out intValue))
                {
                    row.Add(intValue);
                }
                else
                {
                    Debug.LogError("Failed to parse int value: " + value);
                }
            }

            data.Add(row);
        }

        return data;
    }
    private void instantiateFromPool(List<List<int>> pool)
    {
        for (int i = 3; i < pool.Count; i++)
        {
            GameObject nPCi = Instantiate(NPCPrefab, new Vector3(-301.7f + 297 * 4, 676.7f, 0f), Quaternion.identity);
            nPCi.transform.SetParent(go_NPCParent.transform, false);
            nPCi.GetComponent<NPC>().init(pool[i][0], pool[i][1], pool[i][2], pool[i][3], 1);
            if(i<13)
                nPCi.GetComponent<NPC>().face.sprite = controller.getNPCFace(1);
            else if(i<23)
                nPCi.GetComponent<NPC>().face.sprite = controller.getNPCFace(2);
            else
                nPCi.GetComponent<NPC>().face.sprite = controller.getNPCFace(3);
        }
    }
}