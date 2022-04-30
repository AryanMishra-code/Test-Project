using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [Header("Iem Info")]
    public string Name;
    public string Description;
    public Sprite Icon;
    
    [Header("Item Properties")]
    public GameObject prefab;
    public ItemLevel itemLevel;


    public virtual void Use()
    {
        Debug.Log(Name + " was used.");
    }
}

public enum ItemLevel { Level1, Level2, Level3}