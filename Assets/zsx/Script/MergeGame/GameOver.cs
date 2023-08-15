using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour, IPointerClickHandler
{
    public GameObject Success;
    public GameObject Fail;
    [SerializeField]
    private GameObject thisObject;
    [SerializeField]
    private GameObject MergeGame;
    // Start is called before the first frame update

    public void SetFail()
    {
        Fail.SetActive(true);
    }
    public void SetSuccess()
    {
        Success.SetActive(true);
    }
    public void OpenInventory()
    {
        thisObject.SetActive(true);
    }

    public void CloseInventory()
    {

        thisObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Success.SetActive(false);
        Fail.SetActive(false);
        Destroy(MergeGame);
        
    }

}
