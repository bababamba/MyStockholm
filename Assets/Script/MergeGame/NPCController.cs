using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    NPC[] nPCs;
    [SerializeField]
    NPC N1, N2, N3;
    private int curNum = 3;

    [SerializeField]
    private Sprite[] NPCImage;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
        //-301.7f 297f
        if (N1.GetComponent<RectTransform>().anchoredPosition.x < -288f && N1.GetComponent<RectTransform>().anchoredPosition.x > -312f && N1.numberOfNeedy != 0)
        {
            N1.canMove = false;
            N1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-301.7f, 676.7f);
        }
        if (N2.GetComponent<RectTransform>().anchoredPosition.x < 9f && N2.GetComponent<RectTransform>().anchoredPosition.x > -17f && N2.numberOfNeedy != 0)
        {
            N2.canMove = false;
            N2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-4.7f, 676.7f);
        }
        if (N3.GetComponent<RectTransform>().anchoredPosition.x < 299f && N3.GetComponent<RectTransform>().anchoredPosition.x > 280f && N3.numberOfNeedy != 0)
        {
            N3.canMove = false;
            N3.GetComponent<RectTransform>().anchoredPosition = new Vector2(292.3f, 676.7f);
        }


    }

    public void satisfied(NPC P)
    {
        if (N1 == P)
        {
            N1 = N2;
            N2 = N3;
            N3 = nPCs[curNum];
            curNum++;
            N1.canMove = true;
            N2.canMove = true;
            N3.canMove = true;
        }
        if (N2 == P)
        {
            N2 = N3; 
            N3 = nPCs[curNum];
            curNum++;
            N2.canMove = true;
            N3.canMove = true;
        }
        if (N3 == P)
        {
            N3 = nPCs[curNum];
            N3.canMove = true;
            curNum++;
        }

    }
    public void init()
    {
        nPCs = GetComponentsInChildren<NPC>();
        N1 = nPCs[0];
        N2 = nPCs[1];
        N3 = nPCs[2];
    }
    public Sprite getNPCFace(int age)
    {
        int temp = Random.Range(0, 6);
        temp += age * 6;

        return NPCImage[temp];
    }
}
