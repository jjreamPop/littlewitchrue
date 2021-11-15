using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAround : MonoBehaviour
{

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    public float yAmplitude = 0.2f;
    public float yFrequency = 0.75f;
    public float yOffset = 0F;
    public bool yCos = false;
    public float yParentScale = 1f;
    public float yParentOffset = 0f;

    public float xAmplitude = 0.2f;
    public float xFrequency = 0.75f;
    public float xOffset = 0F;
    public bool xCos = false;
    public float xParentScale = 1f;
    public float xParentOffset = 0f;

    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = getTempPosition();

        if (yCos)
        {
            tempPos.y += Mathf.Cos(Time.fixedTime * Mathf.PI * yFrequency + yOffset) * yAmplitude;
        }
        else
        {
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * yFrequency + yOffset) * yAmplitude;
        }

        if (xCos)
        {
            tempPos.x += Mathf.Cos(Time.fixedTime * Mathf.PI * xFrequency + xOffset) * xAmplitude;
        }
        else
        {
            tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * xFrequency + xOffset) * xAmplitude;
        }

        transform.position = tempPos;
    }

    private Vector3 getTempPosition()
    {
        if (transform.parent == null || transform.parent.gameObject.tag == "organizer")
        {
            return posOffset;
        }

        Vector3 parentPos = transform.parent.position;
        Vector3 newPos = new Vector3(parentPos.x + xParentScale * xParentOffset, parentPos.y + yParentScale * yParentOffset);

        return newPos;
    }
}
