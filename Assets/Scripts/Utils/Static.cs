using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    private void Awake()
    {
        Instance = this as T;
    }
}
