using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private void Awake() 
    {
        var obj = FindObjectsOfType<BGM>();

        if(obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else 
            Destroy(gameObject);
    }
}
