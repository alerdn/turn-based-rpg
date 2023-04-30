using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjects : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
