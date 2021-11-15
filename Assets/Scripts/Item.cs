using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string type;

    void Start()
    {
        Debug.Log("I, a [" + type + "], was created");
    }

    void Update()
    {
    }
}
