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
    [SerializeField] private RectTransform dropArea;
    [SerializeField] private RectTransform dropAreaAbove;
    [SerializeField] private RectTransform dropAreaUnder;
    [SerializeField] private RectTransform invArea;
    [SerializeField] GameObject buildEffect1;
    [SerializeField] GameObject buildEffect2;
    public RectTransform currentDropArea;
    private bool isInsideDropArea;

    public bool isFirstBuilt = true;

    private void Start()
    {
        itemTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = itemTransform.position;
        isInsideDropArea = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        itemTransform.position = new Vector3(mousePos.x, mousePos.y, itemTransform.position.z);

        if (IsInsideRectTransform(mousePos, dropArea))
        {
            currentDropArea = dropArea;
            isInsideDropArea = true;
            float scaleY = Mathf.Clamp(2 + (dropArea.position.y - mousePos.y), 1, 5) * 2.3f;
            itemTransform.localScale = new Vector3(scaleY, scaleY, itemTransform.localScale.z);
        }
        else if (IsInsideRectTransform(mousePos, invArea))
        {
            currentDropArea = invArea;
            itemTransform.localScale = Vector3.one;
            isInsideDropArea = true;
        }
        else if (IsInsideRectTransform(mousePos, dropAreaAbove))
        {
            currentDropArea = dropAreaAbove;
            isInsideDropArea = true;
        }
        else if (IsInsideRectTransform(mousePos, dropAreaUnder))
        {
            currentDropArea = dropAreaUnder;
            isInsideDropArea = true;
        }
        else
        {
            currentDropArea = null;
            isInsideDropArea = false;
        }
    }

    private bool IsInsideRectTransform(Vector3 point, RectTransform rectTransform)
    {
        Vector2 rectMin = rectTransform.rect.min;
        Vector2 rectMax = rectTransform.rect.max;
        Vector2 normalizedPoint = rectTransform.InverseTransformPoint(point);

        return normalizedPoint.x >= rectMin.x && normalizedPoint.x <= rectMax.x &&
               normalizedPoint.y >= rectMin.y && normalizedPoint.y <= rectMax.y;
    }

    IEnumerator Build(Vector3 _placedPos, Vector3 _effectPos)
    {
        if (currentDropArea == dropArea)
        {
            if (isFirstBuilt == true)
            {
                isFirstBuilt = false;
                GameObject effect1 = Instantiate(buildEffect1);
                effect1.transform.position = _effectPos;
                effect1.transform.localScale = itemTransform.localScale / 2;
                effect1.transform.parent = effectCanvasParent;

                yield return new WaitForSeconds(1f);
                Destroy(effect1);

                GameObject effect2 = Instantiate(buildEffect2);
                effect2.transform.position = _effectPos;
                effect2.transform.localScale = itemTransform.localScale / 2;
                effect2.transform.parent = effectCanvasParent;
                Destroy(effect2, 1f);
            }

            itemTransform.GetComponent<Image>().enabled = true;
            itemTransform.SetParent(dropArea, false);
            itemTransform.SetAsLastSibling();
            itemTransform.position = _placedPos;
        }
        else
        {
            Vector2 _newPos = itemTransform.anchoredPosition;
            _newPos.y = _placedPos.y;
            itemTransform.anchoredPosition = _newPos;

            if (isFirstBuilt == true)
            {
                isFirstBuilt = false;
                GameObject effect1 = Instantiate(buildEffect1);
                effect1.transform.localScale = itemTransform.localScale * 100;
                effect1.transform.SetParent(effectCanvasParent, false);
                Vector3 effectPos = new Vector3(_newPos.x, -268, 10); // Set the desired z value here
                effect1.GetComponent<RectTransform>().anchoredPosition3D = effectPos;

                yield return new WaitForSeconds(1f);
                Destroy(effect1);

                GameObject effect2 = Instantiate(buildEffect2);

                effect2.transform.localScale = itemTransform.localScale * 100;
                effect2.transform.SetParent(effectCanvasParent, false);
                effect2.GetComponent<RectTransform>().anchoredPosition3D = effectPos;
            }

            itemTransform.GetComponent<Image>().enabled = true;
            itemTransform.SetParent(dropArea, false);
            itemTransform.SetAsLastSibling();
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isInsideDropArea && currentDropArea != null)
        {
            Vector3 _mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            Vector3 _placedPos;
            Vector3 _effectPos;

            if (currentDropArea == dropAreaAbove)
            {
                Debug.Log("Above");
                _placedPos = new Vector3(_mousePos.x, dropArea.rect.max.y, itemTransform.position.z);
            }
            else if (currentDropArea == dropAreaUnder)
            {
                Debug.Log("Under");
                _placedPos = new Vector3(_mousePos.x, dropArea.rect.min.y, itemTransform.position.z);
            }
            else
            {
                Debug.Log("Inside");
                _placedPos = new Vector3(_mousePos.x, _mousePos.y, itemTransform.position.z);
            }

            if (currentDropArea == invArea)
            {
                itemTransform.SetParent(invArea);
                itemTransform.SetAsLastSibling();
                itemTransform.localScale = Vector3.one;
                itemTransform.anchoredPosition = _placedPos;
            }
            else
            {
                _effectPos = _placedPos + new Vector3(0, 0, -100);
                itemTransform.GetComponent<Image>().enabled = false;
                StartCoroutine(Build(_placedPos, _effectPos));
            }
        }
        else
        {
            itemTransform.SetParent(startParent);
            itemTransform.position = startPosition;
        }
    }
}
