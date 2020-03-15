using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryController))]
public class FoodFiring : MonoBehaviour
{
    [SerializeField] private float firingPower = 20.0f;
    [SerializeField] private GameObject foodPrefab;
    private InventoryController inventory;

    private void Start()
    {
        inventory = GetComponent<InventoryController>();
    }

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
            GameObject firedFood = Instantiate(foodPrefab, Camera.main.transform.position + Camera.main.transform.forward * 3.0f, Camera.main.transform.rotation);

            firedFood.GetComponentInChildren<SpriteRenderer>().sprite = FoodSpriteData.GetSprite((int)foodToFire);
            firedFood.GetComponent<IngredientIdentifier>().SetFoodType(foodToFire);
            firedFood.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * firingPower, ForceMode.Impulse);
        }
    }
}
