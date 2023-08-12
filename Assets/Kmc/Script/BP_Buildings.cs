using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BP_Buildings : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform itemTransform; // 아이템 위치

    [SerializeField] private Transform startParent; // 아이템의 처음 parent
    public Vector3 startPosition; // 아이템의 처음 위치 
    [SerializeField] Transform effectCanvasParent;

    [SerializeField] private RectTransform[] dropAreas; // 해당 아이템이 드랍 가능한 Rect Transform 들
    public RectTransform selectedArea; // 드래그중 현재 밑에 있는 Rect Transform
    public bool isInsideDropArea; // 드랍 가능한 위치에 있는가?

    [SerializeField] GameObject buildEffect1;
    [SerializeField] GameObject buildEffect2;

    private void Start()
    {
        itemTransform = GetComponent<RectTransform>();
        startPosition = itemTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isInsideDropArea = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemTransform.position = eventData.position;

        isInsideDropArea = false;

        for (int i = 0; i < dropAreas.Length; i++)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(dropAreas[i], eventData.position))
            {
                selectedArea = dropAreas[i];
                isInsideDropArea = true;

                startPosition = new Vector2(eventData.position.x, selectedArea.position.y);
                startParent = this.transform.parent;

                if(selectedArea.name == "TempInventory_")
                {
                    this.transform.localScale = new Vector3(1, 1, 1);
                }
                else if(selectedArea.name == "LowBuild_")
                {
                    this.transform.localScale = new Vector3(2, 2, 2);
                }
                else
                {
                    this.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
                }

                break;
            }
        }
    }

    IEnumerator Build(Vector2 _placedPos)
    {
        GameObject _effect = Instantiate(buildEffect1);
        _effect.transform.parent = effectCanvasParent;
        _effect.transform.position = _placedPos;

        yield return new WaitForSeconds(1.5f);
        Destroy(_effect);

        GameObject _effect2 = Instantiate(buildEffect2);
        _effect2.transform.position = _placedPos;
        _effect2.transform.parent = effectCanvasParent;

        Destroy(_effect2, 2f);
        
        itemTransform.GetComponent<Image>().enabled = true;
        itemTransform.position = _placedPos;
        itemTransform.SetParent(selectedArea);
        itemTransform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isInsideDropArea && selectedArea != null)
        {   
            if(selectedArea.name == "TempInventory_")
            {
                itemTransform.position = new Vector2(eventData.position.x, selectedArea.position.y);
                itemTransform.SetParent(selectedArea);
                itemTransform.SetAsLastSibling();
            }
            else
            {
                itemTransform.GetComponent<Image>().enabled =false;
                Vector2 _placedPos = new Vector2(eventData.position.x, selectedArea.position.y);
                StartCoroutine(Build(_placedPos));
            }

        }   

        else
        {
            itemTransform.SetParent(startParent);
            itemTransform.position = startPosition;
        }
    }

    
}