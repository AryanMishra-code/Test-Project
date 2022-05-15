using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();

    public InventoryObject inventory;
    public InventoryObject mainHotBarEquipment;
    public InventoryObject leftHandEquipment;
    
    [SerializeField] GameObject inventoryHUD;

    bool inventoryPanelIsVisible = false;
    bool canAddItemToInventory;

    public void OnTriggerEnter(Collider other)
    {
        EquipItem(other);
    }

    private void EquipItem(Collider other)
    {
        var item = other.GetComponent<GroundItem>();

        if (item)
        {
            for (int i = 0; i < mainHotBarEquipment.Container.Items.Length; i++)
            {
                if (mainHotBarEquipment.Container.Items[i].ID <= 1)
                    canAddItemToInventory = false;
                
                else
                    canAddItemToInventory = true;
            }

            if (canAddItemToInventory)
                inventory.AddItem(new Item(item.item), 1);
            else
                mainHotBarEquipment.AddItem(new Item(item.item), 1);

            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            inventory.Load();
        }
        
        InventoryPanelCheck();
    }

    private void InventoryPanelCheck()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryPanelIsVisible)
            {
                inventoryPanelIsVisible = true;
            }
            else
            {
                inventoryPanelIsVisible = false;
            }
        }

        if (inventoryPanelIsVisible)
        {
            inventoryHUD.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GetComponent<PlayerController>().enabled = false;
            GetComponentInChildren<CameraMouseLook>().enabled = false;
        }
        else
        {
            inventoryHUD.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            GetComponent<PlayerController>().enabled = true;
            GetComponentInChildren<CameraMouseLook>().enabled = true;
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        mainHotBarEquipment.Container.Clear();
        leftHandEquipment.Container.Clear();
    }
}