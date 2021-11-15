using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public float resetX = -6;
    public float resetY = -3;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hazard")
        {
            // Play hurt sound

            Vector3 pos = new Vector3(resetX, resetY);
            transform.position = pos;
        }
    }
}
