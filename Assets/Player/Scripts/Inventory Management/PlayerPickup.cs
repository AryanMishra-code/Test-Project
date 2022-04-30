using System;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;

    private Camera camera;

    private Inventory inventory;

    private void Start()
    {
        GetReferences();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                Debug.Log("Hit: " + hit.transform.name);
                Item newItem = hit.transform.GetComponent<ItemObject>().item as Item;
                inventory.AddItem(newItem);
                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void GetReferences()
    {
        camera = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
    }
}