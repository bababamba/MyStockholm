using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Manager : MonoBehaviour
{
    [SerializeField] GameObject questpageObj;
    [SerializeField] GameObject buildpageObj;
    [SerializeField] GameObject mainPageObj;
    [SerializeField] GameObject cameraPageObj;

    public GameObject inventory;
    public GameObject inventoryOnButton;

    public void ToQuestPage()
    {
        buildpageObj.SetActive(false);
        questpageObj.SetActive(true);
    }

    public void ToMainPage()
    {
        buildpageObj.SetActive(true);
        questpageObj.SetActive(false);
    }

    public void CameraOn()
    {
        mainPageObj.SetActive(false);
        questpageObj.SetActive(false);
        cameraPageObj.SetActive(true);
    }  

    public void CameraOff()
    {    
        cameraPageObj.SetActive(false);    
        mainPageObj.SetActive(true);
    }

    public void InvOpen()
    {
        inventoryOnButton.SetActive(false);
        inventory.SetActive(true);
        mainPageObj.SetActive(false);
    }

    public void InvClose()
    {
        inventoryOnButton.SetActive(true);
        inventory.SetActive(false);
        mainPageObj.SetActive(true);
    }

    
}
