using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    [SerializeField] GameObject inventoryPanel;

    bool inventoryPanelIsVisible = false;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();

        if (item)
        {
            inventory.AddItem(new Item(item.item), 1);
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
            inventoryPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GetComponent<PlayerController>().enabled = false;
            GetComponentInChildren<CameraMouseLook>().enabled = false;
        }
        else
        {
            inventoryPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            GetComponent<PlayerController>().enabled = true;
            GetComponentInChildren<CameraMouseLook>().enabled = true;
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[30];
    }
}