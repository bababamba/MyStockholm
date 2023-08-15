using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    public float horizontalSpeed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        if (GetComponent<RectTransform>().anchoredPosition.x>1525)
            GetComponent<RectTransform>().anchoredPosition = new Vector2(-1525, GetComponent<RectTransform>().anchoredPosition.y);
    }
}
