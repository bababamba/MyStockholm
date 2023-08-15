using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anime2frame : MonoBehaviour
{
    [SerializeField]
    Sprite first;
    [SerializeField]
    Sprite second;
    [SerializeField]
    Image image;
    public float timer = 0;

    bool isFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0f;
            switchFrame();
        }
    }
    void switchFrame()
    {
        if (isFirst)
        {
            isFirst = false;
            image.sprite = second;
        }
        else
        {
            isFirst = true;
            image.sprite = first;
        }
    }

}
