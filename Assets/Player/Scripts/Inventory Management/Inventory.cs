using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    public int inventorySize;
    
    private void Start()
    {
        InitVariables();
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int) newItem.weaponLevel;
        
        if (weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;
    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void InitVariables()
    {
        weapons = new Weapon[inventorySize];
    }
}