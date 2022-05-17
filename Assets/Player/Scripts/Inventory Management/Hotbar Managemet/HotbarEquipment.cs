using UnityEngine;

public class HotbarEquipment : MonoBehaviour
{
    private int currentItemIndex;
    
    public RectTransform[] hotBarSlots;
    public RectTransform currentHotBarItemIndicator;

    public InventoryObject hotBarItems;

    void Update()
    {
        ProcessScrollWheelInput();
        ProcessKeyInput();
        SetCurrentItem();
    }

    private void SetCurrentItem()
    {
        currentHotBarItemIndicator.position = hotBarSlots[currentItemIndex].position;
    }

    private void ProcessScrollWheelInput()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentItemIndex >= hotBarSlots.Length - 1)
                currentItemIndex = 0;
            else
                currentItemIndex++;
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentItemIndex <= 0)
                currentItemIndex = hotBarSlots.Length - 1;
            else
                currentItemIndex--;
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            currentItemIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            currentItemIndex = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            currentItemIndex = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            currentItemIndex = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            currentItemIndex = 4;
        if (Input.GetKeyDown(KeyCode.Alpha6))
            currentItemIndex = 5;
        if (Input.GetKeyDown(KeyCode.Alpha7))
            currentItemIndex = 6;
        if (Input.GetKeyDown(KeyCode.Alpha8))
            currentItemIndex = 7;
    }
}