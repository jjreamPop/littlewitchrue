using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float degreesPerSecond = 60f;
   
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * degreesPerSecond), Space.World);
    }
}
