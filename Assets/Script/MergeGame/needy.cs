using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
public class needy : MonoBehaviour
{
    public int needType;
    public int needLevel;
    public int needAmount;
    [SerializeField]
     Image itemImage;
    [SerializeField]
    TextMeshProUGUI amountText;
    NPC owner;
    [SerializeField]
    inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("MergeGame").GetComponent<inventory>();
        itemImage.sprite = inventory.getImageOfItem(needType, needLevel);
        owner = transform.parent.parent.GetComponent<NPC>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void init(int  type, int level, int amount = 1)
    {
        amountText.gameObject.SetActive(false);
        needType = type;
        needLevel = level;
        if (level == 0)
            needLevel = 3;
        needAmount = amount;
        if (needAmount > 1)
        {
            amountText.gameObject.SetActive(true);
            amountText.text = "x" + needAmount.ToString();
        }
        
        SetColor(1);
    }
    public void needyGain()
    {
        needAmount--;
        if (needAmount > 1)
        {
            amountText.text = "x" + needAmount.ToString();
        }
        else

            amountText.gameObject.SetActive(false);
        if (needAmount == 0)
        {

           SetColor(0);
            owner.needyClear();

        }
    }
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
}
