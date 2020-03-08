using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGathering : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private InventoryController inventory;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) GatherFood();
    }

    private void GatherFood()
    {
        Debug.Log("GatherFood");
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, Mathf.Infinity))
        {
            FoodIdentifier foodToAdd = hitInfo.collider.GetComponent<FoodIdentifier>();
            if (foodToAdd != null)
            {
                Debug.Log("Hit food.");
                if (inventory.AddFood(foodToAdd.GetFoodType())) Destroy(foodToAdd.gameObject);
                else Debug.Log("Inventory is full!");
            }
        }
    }
}
