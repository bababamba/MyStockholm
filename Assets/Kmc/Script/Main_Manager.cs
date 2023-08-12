using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentPage
{
    None,

    Setting,
    Shop,
    Build,
    Quest,
    Main,
}

public class Main_Manager : MonoBehaviour
{
    [SerializeField] GameObject questpageObj;
    [SerializeField] GameObject buildpageObj;
    [SerializeField] GameObject mainPageObj;

    public GameObject inventory;
    public GameObject inventoryOnButton;

    public CurrentPage currentPage = CurrentPage.None;
    public bool isInvOn = false;

    void Start()
    {
        MainPage();
    }

    public void CloseAllPages()
    {
        questpageObj.SetActive(false);
        buildpageObj.SetActive(false);
    }

    public void QuestPage()
    {
        CloseAllPages();
        if (currentPage == CurrentPage.Quest)
        {
            currentPage = CurrentPage.None;
            questpageObj.SetActive(false);
        }
        else
        {
            currentPage = CurrentPage.Quest;
            questpageObj.SetActive(true);
        }
    }

    public void BuildPage()
    {
        CloseAllPages();
        if (currentPage == CurrentPage.Build)
        {
            currentPage = CurrentPage.None;
            buildpageObj.SetActive(false);
        }
        else
        {
            currentPage = CurrentPage.Build;
            buildpageObj.SetActive(true);
        }
    }

    public void MainPage()
    {
        CloseAllPages();
        if (currentPage == CurrentPage.Main)
        {
            currentPage = CurrentPage.Main;
            mainPageObj.SetActive(false);
        }
        else
        {
            currentPage = CurrentPage.None;
            mainPageObj.SetActive(true);
        }
    }

    public void InvOpen()
    {
        if (isInvOn == true)
        {
            isInvOn = false;
            inventory.SetActive(false);
        }
        else
        {
            isInvOn = true;
            inventory.SetActive(true);
        }

    }

}
