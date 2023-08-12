using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BP_Manager : MonoBehaviour
{
    public static BP_Manager Instance;

    void Awake()
    {
        Instance = this;
    }
}
