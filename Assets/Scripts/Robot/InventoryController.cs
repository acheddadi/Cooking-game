using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    
    [SerializeField] private int inventorySize = 3;
    private List<TypeOfIngredient> inventory = new List<TypeOfIngredient>();

    public bool AddFood(TypeOfIngredient foodToAdd)
    {
        if (inventory.Count < 3) inventory.Add(foodToAdd);
        else return false;

        return true;
    }

    public TypeOfIngredient UseFood()
    {
        TypeOfIngredient foodToUse = TypeOfIngredient.EMPTY;
        if (inventory.Count > 0)
        {
            foodToUse = inventory[0];
            inventory.RemoveAt(0);
        }
        return foodToUse;
    }
}
