using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class inventoryExtream : MonoBehaviour
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
    private GameObject GameOver;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    float timer = 0f;
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
    bool bossClear = false;

    public int BPearned= 0;
    int startPoint = 1;
    int FaceID = 0;

    void Start()
    {
        timer = 100f;
        BossInit(2);


    }
    private void Update()
    {
        if(timer>0 && !bossClear)
            timer-=Time.deltaTime;

        if (timer < 0)
        {
            Fail();
            timer = 0f;
        }
        timerText.text = timer.ToString();


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
            slots[tempList[random]].AddItem(_item);
        }
        else
            Debug.Log("판이 꽉찼습니다!");
    }
    public Sprite getImageOfItem(int _type, int _level)
    {if (_type == 100)
            return itemImage[0];
    else if (_type == 101)
        return itemImage[16];
    else if (_type == 102)
        return itemImage[17];
    else if (_type == 103)
        return itemImage[18];
    else if(_type == 5)
            return itemImage[13 + Random.Range(0,2)];
        
    else
        return itemImage[(_type - 1) * itemTypes + _level];
    }
    private List<List<int>> ReadCSV(TextAsset file)
    {
        List<List<int>> data = new List<List<int>>();

        string[] lines = file.text.Split('\n');
        foreach (string line in lines)
        {
            
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
    private void instantiateFromPool(List<List<int>> pool,int start)
    {
       
        for (int i = 3+(start*10) ; i <10 + (start * 10); i++)
        {
            GameObject nPCi = Instantiate(NPCPrefab, new Vector3(-301.7f + 297 * 4, 676.7f, 0f), Quaternion.identity);
            nPCi.transform.SetParent(go_NPCParent.transform, false);
            Debug.Log(pool[i][0] + " " + pool[i][1] + " " + pool[i][2]);
            nPCi.GetComponent<NPC>().init(pool[i][0], pool[i][1], pool[i][2], 0, 1);
            nPCi.GetComponent<NPC>().face.sprite = controller.getNPCFace(FaceID);
            
        }
    }
    public void getBP()
    {
        BPearned++;
        switch (BPearned)
        {

            case 3:
                slots[19].ClearSlot();
                slots[34].ClearSlot();
                AcquireItem(101);
                break;
            case 7:
                slots[14].ClearSlot();
                slots[15].ClearSlot();
                slots[22].ClearSlot();
                slots[23].ClearSlot();
                slots[29].ClearSlot();
                
                AcquireItem(102);
                break;
            case 12:
                
                slots[13].ClearSlot();
                slots[8].ClearSlot();
                slots[30].ClearSlot();
                slots[31].ClearSlot();
                slots[39].ClearSlot();

                AcquireItem(103);
                break;
            case 19:
                clearPaper();
                break;

            default:
                break;

        }
    }
    void initBorad()
    {
        for (int i = 0; i < slots.Length; i++)//랜덤한 빈 위치에 아이템 떨구기
        {
            if (slots[i].itemType == 0)
            {
                slots[i].itemImage.GetComponent<RectTransform>().sizeDelta = new Vector2(150,150);
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
        for (int i = 0; i < slots.Length; i++)//랜덤한 빈 위치에 아이템 떨구기
        {
            if (slots[i].itemType == 5)
            { 
                slots[i].ClearSlot();
            }
        }
    }
    public void BossInit(int stage)
    {
        switch (stage)
        {
            case 1:
                timer = 70f;
                startPoint = 1;
                FaceID = 1;
                CommonInit();
                
                break;
            case 2:
                timer = 70f;
                startPoint = 2;
                FaceID = 2;
                
                CommonInit();
                AcquireItem(101);
                break;
            case 3:
                timer = 70f;
                startPoint = 3;
                AcquireItem(101);
                AcquireItem(102);
                FaceID = 3;
                CommonInit();
                break;
            case 4:
                timer = 70f;
                startPoint = 4;
                AcquireItem(101);
                AcquireItem(102);
                AcquireItem(103);
                FaceID = 3;
                CommonInit();
                break;
            case 5:
                timer = 70f;
                startPoint = 5;
                AcquireItem(101);
                AcquireItem(102);
                AcquireItem(103);
                FaceID = 4;
                CommonInit();
                break;
            case 6:
                timer = 70f;
                startPoint = 6;
                AcquireItem(101);
                AcquireItem(102);
                AcquireItem(103);
                FaceID = 4;
                CommonInit();
                break;
        }

    }
    public void CommonInit()
    {
        bossClear = false;

        List<List<int>> questPool = ReadCSV(csvFile);
        slots = go_SlotsParent.GetComponentsInChildren<slot>();
        controller = go_NPCParent.GetComponent<NPCController>();
        //slots[5].AddItem(100);
        AcquireItem(100);
        //gameObject.SetActive(false);
        GameObject nPC = Instantiate(NPCPrefab, new Vector3(-301.7f, 676.7f, 0f), Quaternion.identity);
        nPC.transform.SetParent(go_NPCParent.transform, false);
        startPoint--;
        nPC.GetComponent<NPC>().init(questPool[startPoint*10][0], questPool[startPoint * 10][1], questPool[startPoint * 10][2], 0, 1);
        nPC.GetComponent<NPC>().face.sprite = controller.getNPCFace(FaceID);
        for (int i = 0; i < 2; i++)
        {
            GameObject nPCi = Instantiate(NPCPrefab, new Vector3(-301.7f + 297 * (i + 1), 676.7f, 0f), Quaternion.identity);
            nPCi.transform.SetParent(go_NPCParent.transform, false);
            nPCi.GetComponent<NPC>().init(questPool[startPoint * 10 + i + 1][0], questPool[startPoint * 10 + i + 1][1], questPool[startPoint * 10 + i + 1][2], 0, 1);
            nPCi.GetComponent<NPC>().face.sprite = controller.getNPCFace(FaceID);
        }
        instantiateFromPool(questPool, startPoint);
        controller.init();
        controller.isBoss = true;
    }
    public void Clear()
    {
        bossClear = true;
        GameOver.SetActive(true);
        GameOver.GetComponent<GameOver>().SetSuccess();
    }
    public void Fail()
    {
        GameOver.SetActive(true);
        GameOver.GetComponent<GameOver>().SetFail();
    }
}