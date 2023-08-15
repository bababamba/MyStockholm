using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[System.Serializable]
public class ItemData
{
    public GameObject InvItem;
    public bool isSolded = false;
    public GameObject SoldSign;
    public Button buyButton;
}

public class Shop_Manager : MonoBehaviour
{

    public ItemData item1;
    public ItemData item2;
    public ItemData item3;
    public ItemData item4;
    public ItemData item5;
    public ItemData item6;
    public ItemData item7;
    public ItemData item8;
    public ItemData item9;

    public void BuyItem1()
    {
        if (item1.isSolded != true)
        {
            if (Main_Manager.Instance.BuyItem(200))
            {
                item1.isSolded = true;
                Audio_Manager.Instance.SFX_BuyItem();
                item1.SoldSign.SetActive(true);
                item1.buyButton.interactable = false;
                item1.InvItem.SetActive(true);
            }
            else
            {
                Audio_Manager.Instance.SFX_WrongItem();
            }
        }

    }

    public void BuyItem2()
    {
        if (item2.isSolded != true)
        {
            if (Main_Manager.Instance.BuyItem(500))
            {
                item2.isSolded = true;
                Audio_Manager.Instance.SFX_BuyItem();
                item2.SoldSign.SetActive(true);
                item2.buyButton.interactable = false;
                item2.InvItem.SetActive(true);
            }
            else
            {
                Audio_Manager.Instance.SFX_WrongItem();
            }
        }

    }

    public void BuyItem3()
    {
        if (item3.isSolded != true)
        {
            if (Main_Manager.Instance.BuyItem(1000))
            {
                item3.isSolded = true;
                Audio_Manager.Instance.SFX_BuyItem();
                item3.SoldSign.SetActive(true);
                item3.buyButton.interactable = false;
                item3.InvItem.SetActive(true);
            }
            else
            {
                Audio_Manager.Instance.SFX_WrongItem();
            }
        }

    }

    public void BuyItem4()
    {
        if (item4.isSolded != true)
        {
            if (Main_Manager.Instance.BuyItem(1200))
            {
                item4.isSolded = true;
                Audio_Manager.Instance.SFX_BuyItem();
                item4.SoldSign.SetActive(true);
                item4.buyButton.interactable = false;
                item4.InvItem.SetActive(true);
            }
            else
            {
                Audio_Manager.Instance.SFX_WrongItem();
            }
        }

    }

    public void BuyItem5()
    {
        if (item5.isSolded != true)
        {
            if (Main_Manager.Instance.BuyItem(1500))
            {
                item5.isSolded = true;
                Audio_Manager.Instance.SFX_BuyItem();
                item5.SoldSign.SetActive(true);
                item5.buyButton.interactable = false;
                item5.InvItem.SetActive(true);
            }
            else
            {
                Audio_Manager.Instance.SFX_WrongItem();
            }
        }

    }

    public void BuyItem6()
    {
        if (item6.isSolded != true)
        {
            item6.isSolded = true;
            if (Main_Manager.Instance.BuyItem(2000))
            {
                Audio_Manager.Instance.SFX_BuyItem();
                item6.SoldSign.SetActive(true);
                item6.buyButton.interactable = false;
                item6.InvItem.SetActive(true);
            }
            else
            {
                Audio_Manager.Instance.SFX_WrongItem();
            }
        }

    }

    public void BuyItem7()
    {
        if (item7.isSolded != true)
        {
            if (Main_Manager.Instance.BuyItem(2200))
            {
                item7.isSolded = true;
                Audio_Manager.Instance.SFX_BuyItem();
                item7.SoldSign.SetActive(true);
                item7.buyButton.interactable = false;
                item7.InvItem.SetActive(true);
            }
            else
            {
                Audio_Manager.Instance.SFX_WrongItem();
            }
        }

    }

    public void BuyItem8()
    {
        if (item8.isSolded != true)
        {
            if (Main_Manager.Instance.BuyItem(2500))
            {
                item8.isSolded = true;
                Audio_Manager.Instance.SFX_BuyItem();
                item8.SoldSign.SetActive(true);
                item8.buyButton.interactable = false;
                item8.InvItem.SetActive(true);
            }
            else
            {
                Audio_Manager.Instance.SFX_WrongItem();
            }
        }

    }
    public void BuyItem9()
    {
        if (item9.isSolded != true)
        {
            if (Main_Manager.Instance.BuyItem(3000))
            {
                item9.isSolded = true;
                Audio_Manager.Instance.SFX_BuyItem();
                item9.SoldSign.SetActive(true);
                item9.buyButton.interactable = false;
                item9.InvItem.SetActive(true);
            }
            else
            {
                Audio_Manager.Instance.SFX_WrongItem();
            }
        }

    }
}
