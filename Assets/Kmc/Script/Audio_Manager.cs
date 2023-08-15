using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager Instance;

    void Start()
    {
        Instance = this;
    }

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public AudioClip Title;
    public AudioClip Merge;
    public AudioClip Tutorial;
    public AudioClip Boss;

    public AudioClip ClickBucket;
    public AudioClip PushItem;
    public AudioClip ItemMerge;
    public AudioClip QuestDone;
    public AudioClip WrongItem;
    public AudioClip ButtonClick;
    public AudioClip MapFull;
    public AudioClip BossNoTime;
    public AudioClip BossWinGetItem;
    public AudioClip GameOver;
    public AudioClip BuyItem;


    public void BGM_Title()
    {
        bgmSource.clip = Title;
        bgmSource.Play();
    }
    public void BGM_Merge()
    {
        bgmSource.clip = Merge;
        bgmSource.Play();
    }
    public void BGM_Tutorial()
    {
        bgmSource.clip = Tutorial;
        bgmSource.Play();
    }
    public void BGM_Boss()
    {
        bgmSource.clip = Boss;
        bgmSource.Play();
    }

    public void SFX_ClickBucket()
    {
        sfxSource.PlayOneShot(ClickBucket);
    }
    public void SFX_PushItem()
    {
        sfxSource.PlayOneShot(PushItem);
    }
    public void SFX_ItemMerge()
    {
        sfxSource.PlayOneShot(ItemMerge);
    }
    public void SFX_QuestDone()
    {
        sfxSource.PlayOneShot(QuestDone);
    }
    public void SFX_WrongItem()
    {
        sfxSource.PlayOneShot(WrongItem);
    }
    public void SFX_ButtonClick()
    {
        sfxSource.PlayOneShot(ButtonClick);
    }
    public void SFX_MapFull()
    {
        sfxSource.PlayOneShot(MapFull);
    }
    public void SFX_BossNoTime()
    {
        sfxSource.PlayOneShot(BossNoTime);
    }
    public void SFX_BossWinGetItem()
    {
        sfxSource.PlayOneShot(BossWinGetItem);
    }
    public void SFX_GameOver()
    {
        sfxSource.PlayOneShot(GameOver);
    }
    public void SFX_BuyItem()
    {
        sfxSource.PlayOneShot(BuyItem);
    }
}
