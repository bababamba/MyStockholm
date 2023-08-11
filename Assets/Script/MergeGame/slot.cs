using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;

public class slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public int itemType = 0;
    public int itemLevel = 0; // �۷�
    public Image itemImage;  // �������� �̹���


    [SerializeField]
    private inventory inventory;

    private int levelLimit = 3;

    void Start()
    {
        inventory = GameObject.Find("MergeGame").GetComponent<inventory>();
    }
    // ������ �̹����� ���� ����
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
        
        itemImage.sprite = inventory.getImageOfItem(itemType,itemLevel) ;

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
        SetColor(0);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (itemType == 100)
                inventory.AcquireItem(1);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemType != 0)
        {
            dragSlot.instance.dragslot = this;
            dragSlot.instance.DragSetImage(itemImage);
            dragSlot.instance.transform.position = eventData.position;
        }
    }

    // ���콺 �巡�� ���� �� ��� �߻��ϴ� �̺�Ʈ
    public void OnDrag(PointerEventData eventData)
    {
        if (itemType != 0)
            dragSlot.instance.transform.position = eventData.position;
    }

    // ���콺 �巡�װ� ������ �� �߻��ϴ� �̺�Ʈ
    public void OnEndDrag(PointerEventData eventData)
    {
        
        dragSlot.instance.SetColor(0);
        dragSlot.instance.dragslot = null;
        dragSlot.instance.transform.position = new Vector2(0, 0);

    }
    public void OnDrop(PointerEventData eventData)
    {
       
            
        if (dragSlot.instance.dragslot != null && dragSlot.instance.dragslot.itemType == itemType && dragSlot.instance.dragslot.itemLevel == itemLevel && itemLevel<levelLimit)
        {
            
            MergeSlot();
        }
           
    }

    private void MergeSlot()
    {
        int _tempItemType = itemType;
        int _tempItemLevel = itemLevel;
       
        AddItem(dragSlot.instance.dragslot.itemType);
        dragSlot.instance.dragslot.ClearSlot();




    }
}
