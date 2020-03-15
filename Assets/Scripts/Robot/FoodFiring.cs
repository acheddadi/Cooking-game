using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFiring : MonoBehaviour
{
    [SerializeField] private float firingPower = 20.0f;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private InventoryController inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) FireFood();
    }

    private void FireFood()
    {
        TypeOfIngredient foodToFire = inventory.UseFood();

        if (foodToFire != TypeOfIngredient.EMPTY)
        {
            GameObject firedFood = Instantiate(foodPrefab, playerCamera.position + playerCamera.forward * 3.0f, playerCamera.rotation);

            firedFood.GetComponentInChildren<SpriteRenderer>().sprite = FoodSpriteData.GetSprite((int)foodToFire);
            firedFood.GetComponent<IngredientIdentifier>().SetFoodType(foodToFire);
            firedFood.GetComponent<Rigidbody>().AddForce(playerCamera.forward * firingPower, ForceMode.Impulse);

        }
    }
}
