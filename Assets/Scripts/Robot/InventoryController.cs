using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    
    [SerializeField] private int inventorySize = 3;
    private List<TypeOfFood> inventory = new List<TypeOfFood>();

    public bool AddFood(TypeOfFood foodToAdd)
    {
        if (inventory.Count < 3) inventory.Add(foodToAdd);
        else return false;

        return true;
    }

    public TypeOfFood UseFood()
    {
        TypeOfFood foodToUse = TypeOfFood.EMPTY;
        if (inventory.Count > 0)
        {
            foodToUse = inventory[0];
            inventory.RemoveAt(0);
        }
        return foodToUse;
    }
}
