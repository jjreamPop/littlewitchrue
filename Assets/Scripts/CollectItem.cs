using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private List<string> collectedItems = new List<string>();
    private AudioSource tailPickup;
    private AudioSource eyePickup;
    private AudioSource mushPickup;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        tailPickup = audioSources[1];
        eyePickup = audioSources[2];
        mushPickup = audioSources[3];
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "item")
        {
            collect(col.gameObject);
        }
    }

    private void collect(GameObject go)
    {
        Item item = go.GetComponent(typeof(Item)) as Item;
        if (item != null)
        {
            collectedItems.Add(item.type);

            AudioSource pickupSound = null;
            switch(item.type)
            {
                case "tail":
                    pickupSound = tailPickup;
                    break;
                case "eye":
                    pickupSound = eyePickup;
                    break;
                case "mush":
                    pickupSound = mushPickup;
                    break;
                default:
                    pickupSound = tailPickup;
                    break;
            }
            pickupSound.Play();
        }
        Destroy(go);
    }
}
