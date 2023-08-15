using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloon : MonoBehaviour
{
    public float amplitude = 0.2f;
    public float verticalSpeed = 0.7f;// 위아래 움직임 크기
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * verticalSpeed) * amplitude;
        transform.position = new Vector3(transform.position.x, newPosition.y, transform.position.z);
    }
}
