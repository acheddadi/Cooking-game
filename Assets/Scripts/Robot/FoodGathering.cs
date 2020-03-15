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
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, Mathf.Infinity))
        {
            IngredientIdentifier foodToAdd = hitInfo.collider.GetComponentInParent<IngredientIdentifier>();
            if (foodToAdd != null)
            {
                if (inventory.AddFood(foodToAdd.GetFoodType()) && !foodToAdd.GetSource())Destroy(foodToAdd.gameObject);
            }
        }
    }
}
