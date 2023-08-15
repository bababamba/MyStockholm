using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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


    public bool isBoss = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //-301.7f 297f
        if (N1 != null && N1.GetComponent<RectTransform>().anchoredPosition.x < -208f && N1.GetComponent<RectTransform>().anchoredPosition.x > -392f && N1.numberOfNeedy != 0)
        {
            N1.canMove = false;
            N1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-301.7f, 676.7f);
        }
        if (N2 != null && N2.GetComponent<RectTransform>().anchoredPosition.x < 89f && N2.GetComponent<RectTransform>().anchoredPosition.x > -107f && N2.numberOfNeedy != 0)
        {
            N2.canMove = false;
            N2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-4.7f, 676.7f);
        }
        if (N3 != null && N3.GetComponent<RectTransform>().anchoredPosition.x < 379f && N3.GetComponent<RectTransform>().anchoredPosition.x > 220f && N3.numberOfNeedy != 0)
        {
            N3.canMove = false;
            N3.GetComponent<RectTransform>().anchoredPosition = new Vector2(292.3f, 676.7f);
        }
    }

    public void satisfied(NPC P)
    {
        if (N1 == P)
        {
            if (N2 == null && N3 == null)
            {
                Debug.Log("Clear!");
                transform.parent.GetComponent<inventoryExtream>().Clear();
                isBoss = false;
            }

            if (N2 != null)
                N1 = N2;
            N2 = null;
            if (N3 != null)
                N2 = N3;

            N3 = null;
            if (nPCs.Length != curNum)
            {
                N3 = nPCs[curNum];
                curNum++;
                N3.canMove = true;
            }

            N1.canMove = true;
            if (N2 != null)
                N2.canMove = true;

        }
        if (N2 == P)
        {
            N2 = null;
            if (N3 != null)
                N2 = N3;
            N3 = null;
            if (nPCs.Length != curNum)
            {
                N3 = nPCs[curNum];
                curNum++;
                N3.canMove = true;
            }
            if (N2 != null)
                N2.canMove = true;

        }
        if (N3 == P)
        {
            N3 = null;
            if (nPCs.Length != curNum)
            {
                N3 = nPCs[curNum];
                curNum++;
                N3.canMove = true;
            }
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
        int temp;
        if (age == 4)
        {
            temp = Random.Range(0, 18);
            return NPCImage[temp];
        }
        else
        {
            temp = Random.Range(0, 6);
            temp += ((age - 1) * 6);

            return NPCImage[temp];

        }
    }
}
