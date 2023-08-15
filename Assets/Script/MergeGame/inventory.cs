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


    public TextAsset csvFile;
    public GameObject moneyTarget;

    public GameObject bluePTarget;


    [SerializeField]
    private Sprite[] itemImage;
    [SerializeField]
    private int itemTypes = 3;
    [SerializeField]
    private slot[] slots;  // ���Ե� �迭

    private NPCController controller;

    public int BPearned = 0;

    void Start()
    {
        List<List<int>> questPool = ReadCSV(csvFile);
        slots = go_SlotsParent.GetComponentsInChildren<slot>();
        controller = go_NPCParent.GetComponent<NPCController>();
        initBorad();
        //slots[5].AddItem(100);
        AcquireItem(100);
        //gameObject.SetActive(false);
        GameObject nPC = Instantiate(NPCPrefab, new Vector3(-301.7f, 676.7f, 0f), Quaternion.identity);
        nPC.transform.SetParent(go_NPCParent.transform, false);
        nPC.GetComponent<NPC>().init(questPool[0][0], questPool[0][1], questPool[0][2], questPool[0][3], 1);
        nPC.GetComponent<NPC>().face.sprite = controller.getNPCFace(1);
        for (int i = 0; i < 2; i++)
        {
            GameObject nPCi = Instantiate(NPCPrefab, new Vector3(-301.7f + 297 * (i + 1), 676.7f, 0f), Quaternion.identity);
            nPCi.transform.SetParent(go_NPCParent.transform, false);
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

    public void AcquireItem(int _item)
    {
        Audio_Manager.Instance.SFX_ClickBucket();
        List<int> tempList = new List<int>();

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
            slots[tempList[random]].AddItem(_item);
        }
        else
            Debug.Log("���� ��á���ϴ�!");
    }
    public Sprite getImageOfItem(int _type, int _level)
    {
        if (_type == 100)
            return itemImage[0];
        else if (_type == 101)
            return itemImage[16];
        else if (_type == 102)
            return itemImage[17];
        else if (_type == 103)
            return itemImage[18];
        else if (_type == 5)
            return itemImage[13 + Random.Range(0, 2)];

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
            if (i < 13)
                nPCi.GetComponent<NPC>().face.sprite = controller.getNPCFace(1);
            else if (i < 23)
                nPCi.GetComponent<NPC>().face.sprite = controller.getNPCFace(2);
            else
                nPCi.GetComponent<NPC>().face.sprite = controller.getNPCFace(3);
        }
    }
    public void getBP()
    {
        BPearned++;

        switch (BPearned)
        {
            case 1: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 2: QP_Manager.Instance.GetPiece(BPearned - 1); break;

            case 3:

                slots[19].ClearSlot();
                slots[34].ClearSlot();
                AcquireItem(101);
                QP_Manager.Instance.GetPiece(BPearned - 1);
                break;

            case 4: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 5: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 6: QP_Manager.Instance.GetPiece(BPearned - 1); break;


            case 7:
                QP_Manager.Instance.GetPiece(BPearned - 1);
                slots[14].ClearSlot();
                slots[15].ClearSlot();
                slots[22].ClearSlot();
                slots[23].ClearSlot();
                slots[29].ClearSlot();

                AcquireItem(102);
                break;

            case 8: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 9: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 10: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 11: QP_Manager.Instance.GetPiece(BPearned - 1); break;

            case 12:
                QP_Manager.Instance.GetPiece(BPearned - 1);
                slots[13].ClearSlot();
                slots[8].ClearSlot();
                slots[30].ClearSlot();
                slots[31].ClearSlot();
                slots[39].ClearSlot();

                AcquireItem(103);
                break;


            case 13: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 14: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 15: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 16: QP_Manager.Instance.GetPiece(BPearned - 1); break;
            case 17: QP_Manager.Instance.GetPiece(BPearned - 1); break;



            case 18:
                QP_Manager.Instance.GetPiece(BPearned - 1);
                clearPaper();
                break;

            default:
                break;

        }
    }
    void initBorad()
    {
        for (int i = 0; i < slots.Length; i++)//������ �� ��ġ�� ������ ������
        {
            if (slots[i].itemType == 0)
            {
                slots[i].itemImage.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
                slots[i].AddItem(5);
            }
        }
        slots[20].ClearSlot();
        slots[21].ClearSlot();
        slots[25].ClearSlot();
        slots[26].ClearSlot();
        slots[27].ClearSlot();
        slots[28].ClearSlot();
        slots[32].ClearSlot();
        slots[33].ClearSlot();

    }
    void clearPaper()
    {
        for (int i = 0; i < slots.Length; i++)//������ �� ��ġ�� ������ ������
        {
            if (slots[i].itemType == 5)
            {
                slots[i].ClearSlot();
            }
        }
    }
}