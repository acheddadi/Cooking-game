using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryController))]
public class FoodGathering : MonoBehaviour
{
    private InventoryController inventory;

    private void Start()
    {
        inventory = GetComponent<InventoryController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) GatherFood();
    }

    private void GatherFood()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, Mathf.Infinity))
        {
            IngredientIdentifier foodToAdd = hitInfo.collider.GetComponentInParent<IngredientIdentifier>();
            if (foodToAdd != null)
            {
                if (inventory.AddFood(foodToAdd.GetFoodType()) && !foodToAdd.GetSource())Destroy(foodToAdd.gameObject);
            }
        }
    }
}
