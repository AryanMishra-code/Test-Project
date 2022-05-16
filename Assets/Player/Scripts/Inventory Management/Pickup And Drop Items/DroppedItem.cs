using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public ItemObject item;
    public int amount;

    void Start()
    {
        gameObject.AddComponent<GroundItem>();
        gameObject.GetComponent<GroundItem>().item = item;
        gameObject.GetComponent<GroundItem>().amount = amount;
    }
}