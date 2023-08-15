using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CurrentPage
{
    None,

    Setting,
    Shop,
    Build,
    Quest,
    Main,
    Merge,
    Credit,
}

public class Main_Manager : MonoBehaviour
{
    public static Main_Manager Instance;

    [SerializeField] GameObject questpageObj;
    [SerializeField] GameObject buildpageObj;
    [SerializeField] GameObject mainPageObj;
    [SerializeField] GameObject mergePageObj;
    [SerializeField] GameObject shopPageObj;
    [SerializeField] GameObject tutorialPageObj;
    [SerializeField] GameObject creditPageObj;


    [SerializeField] GameObject middleTutorialObj;

    [SerializeField] GameObject mainUI;


    public Text moneyText;
    public int money = 0;

    public GameObject inventory;
    public GameObject inventoryOnButton;

    public CurrentPage currentPage = CurrentPage.None;
    public bool isInvOn = false;

    public bool seenMiddleTutorial = false;

    void Awake()
    {
        Instance = this;
        MainPage();

        TurnONEVENRTYING();
    }

    void Start()
    {
        CloseAllPages();
    }

    public void EarnMoney(int _value)
    {
        money = money + _value;
        moneyText.text = money.ToString();
    }

    public void TurnONEVENRTYING()
    {
        questpageObj.SetActive(true);
        buildpageObj.SetActive(true);
        mergePageObj.SetActive(true);
        shopPageObj.SetActive(true);
    }

    public void CloseAllPages()
    {

        questpageObj.SetActive(false);
        buildpageObj.SetActive(false);
        mergePageObj.SetActive(false);
        shopPageObj.SetActive(false);
        creditPageObj.SetActive(false);
    }

    public void EndTutorial()
    {
        Audio_Manager.Instance.SFX_ButtonClick();
        mainUI.SetActive(true);
        tutorialPageObj.SetActive(false);
    }

    public void Credit()
    {
        CloseAllPages();
        Audio_Manager.Instance.SFX_ButtonClick();
        if (currentPage == CurrentPage.Credit)
        {
            currentPage = CurrentPage.None;
            creditPageObj.SetActive(false);
        }
        else
        {
            currentPage = CurrentPage.Credit;
            creditPageObj.SetActive(true);
        }
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void showMiddleTutorial()
    {
        Audio_Manager.Instance.SFX_ButtonClick();
        if (seenMiddleTutorial == false)
        {
            seenMiddleTutorial = true;
            middleTutorialObj.SetActive(true);
        }
    }



    public bool BuyItem(int _value)
    {
        if (money >= _value)
        {
            money = money - _value;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void QuestPage()
    {
        Audio_Manager.Instance.SFX_ButtonClick();
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


    public void ShopPage()
    {
        Audio_Manager.Instance.SFX_ButtonClick();
        CloseAllPages();
        if (currentPage == CurrentPage.Shop)
        {
            currentPage = CurrentPage.None;
            shopPageObj.SetActive(false);
        }
        else
        {
            currentPage = CurrentPage.Shop;
            shopPageObj.SetActive(true);
        }
    }

    public void MergePage()
    {
        Audio_Manager.Instance.SFX_ButtonClick();
        CloseAllPages();
        mainUI.SetActive(true);
        if (currentPage == CurrentPage.Merge)
        {
            Audio_Manager.Instance.BGM_Title();
            currentPage = CurrentPage.None;
            mergePageObj.SetActive(false);
        }
        else
        {
            Audio_Manager.Instance.BGM_Merge();
            currentPage = CurrentPage.Merge;
            mergePageObj.SetActive(true);
        }
    }

    public void OnlyMErge()
    {
        Audio_Manager.Instance.SFX_ButtonClick();
        Audio_Manager.Instance.BGM_Merge();
        mergePageObj.SetActive(true);
    }

    public void BuildPage()
    {
        Audio_Manager.Instance.SFX_ButtonClick();
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
        Audio_Manager.Instance.SFX_ButtonClick();
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
