using UnityEngine;

public class Item : ScriptableObject
{
    [Header("Iem Info")]
    public string Name;
    public string Description;
    public Sprite Icon;
    
    [Header("Item Properties")]
    public GameObject prefab;
    public ItemType itemType;
    
    public virtual void Use()
    {
        Debug.Log(Name + " was used.");
    }
}

public enum ItemType { Melee, HarvestTool, Consumable}