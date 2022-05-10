using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public ItemObject item;
    
    public void Start()
    {
        var objectPrefab = Instantiate(item.objectPrefab, this.transform.position, Quaternion.identity);
        objectPrefab.transform.SetParent(this.transform);
    }
}