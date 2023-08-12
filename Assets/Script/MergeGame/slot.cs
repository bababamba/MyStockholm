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
    public int itemLevel = 0; // 템렙
    public Image itemImage;  // 아이템의 이미지


    [SerializeField]
    private inventoryExtream inventory;

    private int levelLimit = 3;

    void Start()
    {
        inventory = GameObject.Find("MergeGameExtream").GetComponent<inventoryExtream>();
    }
    // 아이템 이미지의 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(int _item, int _level = 1)
    {
        itemType = _item;
        itemLevel += _level;
        
        itemImage.sprite = inventory.getImageOfItem(itemType,itemLevel) ;

        SetColor(1);
    }

    // 해당 슬롯의 아이템 갯수 업데이트
    public void SetSlotLevel(int _Level)
    {
        itemLevel += _Level;
        itemImage.sprite = inventory.getImageOfItem(itemType, itemLevel);
        if (itemLevel <= 0)
            ClearSlot();
    }

    // 해당 슬롯 하나 삭제
    public void ClearSlot()
    {
 
        itemType = 0;
        itemLevel = 0;
        itemImage.sprite = null;
        itemImage.GetComponent<RectTransform>().sizeDelta = new Vector2(120f,120f);
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
        if (itemType != 0 && itemType!=5)
        {
            dragSlot.instance.dragslot = this;
            dragSlot.instance.DragSetImage(itemImage);
            dragSlot.instance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragSlot.instance.transform.position = new Vector3(dragSlot.instance.transform.position.x, dragSlot.instance.transform.position.y, 0);
        }
    }

    // 마우스 드래그 중일 때 계속 발생하는 이벤트
    public void OnDrag(PointerEventData eventData)
    {
        if (itemType != 0)
            dragSlot.instance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragSlot.instance.transform.position = new Vector3(dragSlot.instance.transform.position.x, dragSlot.instance.transform.position.y, 0);
    }

    // 마우스 드래그가 끝났을 때 발생하는 이벤트
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
        if (dragSlot.instance.dragslot != this)
        {
            AddItem(dragSlot.instance.dragslot.itemType);
            dragSlot.instance.dragslot.ClearSlot();
        }




    }
}
