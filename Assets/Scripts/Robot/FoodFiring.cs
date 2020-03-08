using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFiring : MonoBehaviour
{
    [SerializeField] private float firingPower = 20.0f;
    [SerializeField] private GameObject[] foodPrefabs;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private InventoryController inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) FireFood();
    }

    private void FireFood()
    {
        TypeOfFood foodToFire = inventory.UseFood();

        if ((int)foodToFire < foodPrefabs.Length && foodToFire != TypeOfFood.EMPTY)
        {
            GameObject firedFood = Instantiate(foodPrefabs[(int)foodToFire], playerCamera.position + playerCamera.forward * 3.0f, playerCamera.rotation);
            Rigidbody rb = firedFood.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(playerCamera.forward * firingPower, ForceMode.Impulse);
            }
            
        }
        else if (foodToFire != TypeOfFood.EMPTY) Debug.LogError("Food prefab is not set for " + foodToFire + "!");
    }
}
