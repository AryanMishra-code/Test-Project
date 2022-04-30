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
        int newItemIndex = 0;
        
        if (items[newItemIndex] != null)
        {
            newItemIndex += 1;
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