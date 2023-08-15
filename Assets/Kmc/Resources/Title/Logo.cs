using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{
    // Start is called before the first frame update
    public float verticalSpeed = 0.7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<RectTransform>().anchoredPosition.y < 539f)
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        
    }
}
