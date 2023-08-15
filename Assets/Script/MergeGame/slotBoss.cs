using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;

public class slotBoss : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public int itemType = 0;
    public int itemLevel = 0; // �۷�
    public Image itemImage;  // �������� �̹���


    [SerializeField]
    private inventoryExtream inventory;

    private int levelLimit = 3;

    void Start()
    {
        inventory = GameObject.Find("MergeGameExtream(Clone)").GetComponent<inventoryExtream>();
    }
    // ������ �̹����� ������ ����
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // �κ��丮�� ���ο� ������ ���� �߰�
    public void AddItem(int _item, int _level = 1)
    {
        itemType = _item;
        itemLevel += _level;

        itemImage.sprite = inventory.getImageOfItem(itemType, itemLevel);

        SetColor(1);
    }

    // �ش� ������ ������ ���� ������Ʈ
    public void SetSlotLevel(int _Level)
    {
        itemLevel += _Level;
        itemImage.sprite = inventory.getImageOfItem(itemType, itemLevel);
        if (itemLevel <= 0)
            ClearSlot();
    }

    // �ش� ���� �ϳ� ����
    public void ClearSlot()
    {

        itemType = 0;
        itemLevel = 0;
        itemImage.sprite = null;
        itemImage.GetComponent<RectTransform>().sizeDelta = new Vector2(120f, 120f);
        SetColor(0);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (itemType == 100)
                inventory.AcquireItem(1);
            if (itemType == 101)
                inventory.AcquireItem(2);
            if (itemType == 102)
                inventory.AcquireItem(3);
            if (itemType == 103)
                inventory.AcquireItem(4);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemType != 0 && itemType != 5)
        {
            dragSlot.instance.dragslotBoss = this;
            dragSlot.instance.DragSetImage(itemImage);
            dragSlot.instance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragSlot.instance.transform.position = new Vector3(dragSlot.instance.transform.position.x, dragSlot.instance.transform.position.y, 0);
        }
    }

    // ���콺 �巡�� ���� �� ��� �߻��ϴ� �̺�Ʈ
    public void OnDrag(PointerEventData eventData)
    {
        if (itemType != 0)
            dragSlot.instance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragSlot.instance.transform.position = new Vector3(dragSlot.instance.transform.position.x, dragSlot.instance.transform.position.y, 0);
    }

    // ���콺 �巡�װ� ������ �� �߻��ϴ� �̺�Ʈ
    public void OnEndDrag(PointerEventData eventData)
    {

        dragSlot.instance.SetColor(0);
        dragSlot.instance.dragslotBoss = null;
        dragSlot.instance.transform.position = new Vector2(0, 0);

    }
    public void OnDrop(PointerEventData eventData)
    {


        if (dragSlot.instance.dragslotBoss != null && dragSlot.instance.dragslotBoss.itemType == itemType && dragSlot.instance.dragslotBoss.itemLevel == itemLevel && itemLevel < levelLimit)
        {

            MergeSlot();
        }

    }

    private void MergeSlot()
    {
        int _tempItemType = itemType;
        int _tempItemLevel = itemLevel;
        if (dragSlot.instance.dragslotBoss != this)
        {
            AddItem(dragSlot.instance.dragslotBoss.itemType);
            dragSlot.instance.dragslotBoss.ClearSlot();
        }




    }
}
