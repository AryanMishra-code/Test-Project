using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public ItemObject item;
    public int amount;

    void Start()
    {
        if (item.buffs.Length > 0) amount = 1;
        
        var objectPrefab = Instantiate(item.objectPrefab, this.transform.position, Quaternion.identity);
        objectPrefab.transform.SetParent(this.transform);
    }
}