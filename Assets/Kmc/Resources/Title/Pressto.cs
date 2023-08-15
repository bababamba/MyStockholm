using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Pressto : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TMP;
    bool upper = true;
    float alpha = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetColor(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(upper == true)
            alpha += Time.deltaTime;
        else
            alpha -= Time.deltaTime;

        if (alpha < 0)
        {
            upper = true;
            alpha = 0;
        }

        if (alpha > 1)
        {
            upper = false;
            alpha = 1;
        }
        SetColor(alpha);
            
    }
    private void SetColor(float _alpha)
    {
        Color color = TMP.color;
        color.a = _alpha;
        TMP.color = color;
    }
}
