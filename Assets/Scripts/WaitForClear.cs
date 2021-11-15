using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForClear : MonoBehaviour
{

    public GameObject portal;

    void Start()
    {

    }

    void Update()
    {
        if (!portal.activeInHierarchy)
        {
            GameObject[] remainingItems = GameObject.FindGameObjectsWithTag("item");
            if (remainingItems.Length == 0)
            {
                Debug.Log("Level Cleared!!");
                portal.SetActive(true);
            }
        }
    }
}
