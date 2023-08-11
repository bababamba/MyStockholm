using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class inventory : MonoBehaviour
{
    public static bool invectoryActivated = false;  // �κ��丮 Ȱ��ȭ ����. true�� �Ǹ� ī�޶� �����Ӱ� �ٸ� �Է��� ���� ���̴�.

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base �̹���
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot���� �θ��� Grid Setting 
    [SerializeField]
    private GameObject go_NPCParent;
    [SerializeField]
    private GameObject NPCPrefab;  


    [SerializeField]
    private Sprite[] itemImage;
    [SerializeField]
    private int itemTypes = 3;
    [SerializeField]
    private slot[] slots;  // ���Ե� �迭

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

        for (int i = 0; i < slots.Length; i++)//������ �� ��ġ�� ������ ������
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
            Debug.Log("���� ��á���ϴ�!");
    }
    public Sprite getImageOfItem(int _type, int _level)
    {if(_type == 100)
            return itemImage[0];
    else
        return itemImage[(_type - 1) * itemTypes + _level];
    }

}