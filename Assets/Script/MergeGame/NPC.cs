using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static TreeEditor.TreeEditorHelper;
using UnityEngine.EventSystems;

public class NPC : MonoBehaviour, IDropHandler
{

    public float verticalSpeed = 30f; // ���Ʒ� ������ �ӵ�
    public float horizontalSpeed = 100f; // ������ �̵� �ӵ�
    public float amplitude = 20f; // ���Ʒ� ������ ũ��

    private Vector3 startPosition;
    [SerializeField]
    private Image face;

    [SerializeField]
    private GameObject needyGreed;

    public int numberOfNeedy;
    [SerializeField]
    GameObject needyPrefab;
    private needy[] needys;
    
    
    // Start is called before the first frame update
    void Start()
    {
        needys = GetComponentsInChildren<needy>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GoLeft();
    }
    public void init(int number)
    {
        numberOfNeedy = number;
        for(int i=0;i<number;i++)
        {
            GameObject needyObject = Instantiate(needyPrefab);
            needyObject.transform.SetParent(needyGreed.transform,false);
            needyObject.GetComponent<needy>().init(1, i+2, 1);
        }
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

    }
    public void needyClear()
    {
        numberOfNeedy--;
    }
    public void GoLeft()
    {
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * verticalSpeed) * amplitude;
        transform.position = new Vector3(transform.position.x,newPosition.y,transform.position.z);

        // ������ �̵�
        transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
    }
}
