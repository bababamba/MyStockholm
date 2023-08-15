using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class NPC : MonoBehaviour, IDropHandler
{

    public float verticalSpeed = 30f; // ���Ʒ� ������ �ӵ�
    public float horizontalSpeed = 100f; // ������ �̵� �ӵ�
    public float amplitude = 20f; // ���Ʒ� ������ ũ��

    public bool canMove;
    public GameObject coinPrefab;
    public GameObject bluePPrefab;

    private Vector3 startPosition;
    public Image face;
    [SerializeField]
    private Image Reward;
    [SerializeField]
    private Sprite coinS;
    [SerializeField]
    private Sprite BPS;

    [SerializeField]
    private GameObject needyGreed;

    public int numberOfNeedy;
    [SerializeField]
    GameObject needyPrefab;
    private needy[] needys;

    public int rewardType;
    public int rewardCount;

    public int reaction;

    public GameObject moneyTarget;
    public GameObject bluePTarget;
    inventory inven;

    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        needys = GetComponentsInChildren<needy>();
        startPosition = transform.position;
        moneyTarget = GameObject.Find("MoneyTarget");
        bluePTarget = GameObject.Find("BluePTarget");
        if (rewardType != 0)
            inven = GameObject.Find("MergeGame").GetComponent<inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
            GoLeft();
    }
    public void init(int need1, int need2, int need3, int _rewardT, int _rewardC)
    {
        numberOfNeedy = 3;
        rewardType = _rewardT;
        rewardCount = _rewardC;
        if (rewardType == 0)
        {
            if (need1 != 0)
            {

                GameObject needyObject = Instantiate(needyPrefab);
                needyObject.transform.SetParent(needyGreed.transform, false);
                //Debug.Log(need1);
                needyObject.GetComponent<needy>().init(((need1 - 1) / 3) + 1, (need1 - 1) % 3 + 1, true);
            }
            else numberOfNeedy--;
            if (need2 != 0)
            {
                //Debug.Log(need2);
                GameObject needyObject = Instantiate(needyPrefab);
                needyObject.transform.SetParent(needyGreed.transform, false);
                needyObject.GetComponent<needy>().init(((need2 - 1) / 3) + 1, (need2 - 1) % 3 + 1, true);
            }
            else numberOfNeedy--;
            if (need3 != 0)
            {
                //Debug.Log(need3);
                GameObject needyObject = Instantiate(needyPrefab);
                needyObject.transform.SetParent(needyGreed.transform, false);
                needyObject.GetComponent<needy>().init(((need3 - 1) / 3) + 1, (need3 - 1) % 3 + 1, true);
            }
            else numberOfNeedy--;
        }
        else
        {
            if (need1 != 0)
            {

                GameObject needyObject = Instantiate(needyPrefab);
                needyObject.transform.SetParent(needyGreed.transform, false);
                //Debug.Log(need1);
                needyObject.GetComponent<needy>().init(((need1 - 1) / 3) + 1, (need1 - 1) % 3 + 1, false);
            }
            else numberOfNeedy--;
            if (need2 != 0)
            {
                //Debug.Log(need2);
                GameObject needyObject = Instantiate(needyPrefab);
                needyObject.transform.SetParent(needyGreed.transform, false);
                needyObject.GetComponent<needy>().init(((need2 - 1) / 3) + 1, (need2 - 1) % 3 + 1, false);
            }
            else numberOfNeedy--;
            if (need3 != 0)
            {
                //Debug.Log(need3);
                GameObject needyObject = Instantiate(needyPrefab);
                needyObject.transform.SetParent(needyGreed.transform, false);
                needyObject.GetComponent<needy>().init(((need3 - 1) / 3) + 1, (need3 - 1) % 3 + 1, false);
            }
            else numberOfNeedy--;
        }
        if (rewardType == 1)
            Reward.sprite = coinS;
        else if (rewardType == 2)
            Reward.sprite = BPS;
        else
            Reward.gameObject.SetActive(false);


    }
    public void OnDrop(PointerEventData eventData)
    {
        if (dragSlot.instance.dragslot != null)
        {
            for (int i = 0; i < needys.Length; i++)
            {
                if (needys[i].needType != dragSlot.instance.dragslot.itemType)
                    Debug.Log("���� ���ϴ°� �ƴϾ�!");
                else if (dragSlot.instance.dragslot.itemLevel != needys[i].needLevel)
                {
                    if (dragSlot.instance.dragslot.itemLevel > needys[i].needLevel)
                        Debug.Log("���� ���ϴ°����� �ʹ� ����!");
                    else
                        Debug.Log("���� ���ϴ°����� �ʹ� ����!");
                }
                else
                {
                    if (needys[i].needAmount != 0)
                    {
                        Debug.Log("����! ���� ���ϴ��ž�!");
                        needys[i].needyGain();
                        dragSlot.instance.dragslot.ClearSlot();
                        return;
                    }
                }
            }
        }
        if (dragSlot.instance.dragslotBoss != null)
        {
            for (int i = 0; i < needys.Length; i++)
            {
                if (needys[i].needType != dragSlot.instance.dragslotBoss.itemType)
                    Debug.Log("���� ���ϴ°� �ƴϾ�!");
                else if (dragSlot.instance.dragslotBoss.itemLevel != needys[i].needLevel)
                {
                    if (dragSlot.instance.dragslotBoss.itemLevel > needys[i].needLevel)
                        Debug.Log("���� ���ϴ°����� �ʹ� ����!");
                    else
                        Debug.Log("���� ���ϴ°����� �ʹ� ����!");
                }
                else
                {
                    if (needys[i].needAmount != 0)
                    {
                        Debug.Log("����! ���� ���ϴ��ž�!");
                        needys[i].needyGain();
                        dragSlot.instance.dragslotBoss.ClearSlot();
                        return;
                    }
                }
            }
        }


    }
    public void needyClear()
    {
        numberOfNeedy--;
        if (numberOfNeedy == 0)
        {
            Audio_Manager.Instance.SFX_QuestDone();
            canMove = true;
            transform.parent.GetComponent<NPCController>().satisfied(this);
            if (rewardType == 1)
                SpawnCoins();
            if (rewardType == 2)
                SpawnBP();

            Destroy(gameObject, 10);

        }
    }
    public void GoLeft()
    {/*
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * verticalSpeed) * amplitude;
        transform.position = new Vector3(transform.position.x,newPosition.y,transform.position.z);
        */
        // ������ �̵�
        transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
    }
    private void SpawnCoins()
    {
        for (int i = 0; i < rewardCount; i++)
        {
            Vector3 spawnPosition = this.transform.position;
            spawnPosition.z = 0f;
            GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            coin.transform.SetParent(transform, false);
            Vector3 targetDirection = (moneyTarget.transform.position - coin.transform.position).normalized;
            Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
            rb.velocity = targetDirection * 8f;

            Debug.Log("KILED");
            Main_Manager.Instance.EarnMoney(100);
            Debug.Log("ADDINGMOMEY");

            Destroy(coin, 3f); // ������ Ÿ�ٿ� ���� ������ ���� �ð� �Ŀ� ����
        }
    }
    private void SpawnBP()
    {
        for (int i = 0; i < rewardCount; i++)
        {
            Vector3 spawnPosition = this.transform.position;
            spawnPosition.z = 0f;
            GameObject coin = Instantiate(bluePPrefab, spawnPosition, Quaternion.identity);
            coin.transform.SetParent(transform, false);
            Vector3 targetDirection = (moneyTarget.transform.position - coin.transform.position).normalized;
            Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
            rb.velocity = targetDirection * 8f;
            inven.getBP();
            Destroy(coin, 3f); // ������ Ÿ�ٿ� ���� ������ ���� �ð� �Ŀ� ����
        }
    }
}






