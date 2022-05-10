using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundItem : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemObject item;
    public void OnBeforeSerialize()
    {
        // GetComponentInChildren<SpriteRenderer>().sprite = item.uiDisplay;
        // EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
    }

    public void OnAfterDeserialize()
    {
    }

    public void Start()
    {
        var objectPrefab = Instantiate(item.objectPrefab, this.transform.position, Quaternion.identity);
        objectPrefab.transform.SetParent(this.transform);
    }
}