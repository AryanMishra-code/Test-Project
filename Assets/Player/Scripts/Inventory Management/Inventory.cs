using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item[] items;
    public int inventorySize;
    
    private void Start()
    {
        InitVariables();
    }

    public void AddItem(Item newItem)
    {
        int newItemIndex = (int) newItem.itemLevel;
        
        if (items[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        items[newItemIndex] = newItem;
    }

    public void RemoveItem(int index)
    {
        items[index] = null;
    }

    public Item GetItem(int index)
    {
        return items[index];
    }

    private void InitVariables()
    {
        items = new Item[inventorySize];
    }
}