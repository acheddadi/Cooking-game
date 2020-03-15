using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlateRotator))]
public class PlateHolder : MonoBehaviour
{
    private List<IngredientOnPlate> ingredientsOnPlate = new List<IngredientOnPlate>();
    private PlateRotator rotator;

    private class IngredientOnPlate
    {
        private Rigidbody rigidbody;
        private Vector3 targetPosition;

        public IngredientOnPlate(Rigidbody rb)
        {
            rigidbody = rb;
            targetPosition = rb.position;
            rigidbody.isKinematic = true;
        }
        public void MoveTowards(Vector3 target)
        {
            if (Vector3.Distance(target, targetPosition) > 0.5f) targetPosition = Vector3.MoveTowards(targetPosition, target, 2.0f * Time.deltaTime);
            rigidbody.MovePosition(targetPosition);
        }
        public Vector3 GetPosition()
        {
            return rigidbody.position;
        }

        public bool Exists()
        {
            if (rigidbody != null) return true;
            else return false;
        }
    }
    private void Start()
    {
        rotator = GetComponent<PlateRotator>();
    }

    private void Update()
    {
        if (ingredientsOnPlate.Count > 0)
        {
            for (int i = 0; i < ingredientsOnPlate.Count; i++)
            {
                if (!ingredientsOnPlate[i].Exists())
                {
                    ingredientsOnPlate.RemoveAt(i);
                    break;
                }
                else if (i > 0) ingredientsOnPlate[i].MoveTowards(ingredientsOnPlate[i - 1].GetPosition());
                else ingredientsOnPlate[i].MoveTowards(rotator.GetTargetPosition());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IngredientIdentifier ingredientToAdd = other.GetComponent<IngredientIdentifier>();
        if (ingredientToAdd != null)
        {
            if (!ingredientToAdd.GetOnPlate())
            {
                ingredientsOnPlate.Add(new IngredientOnPlate(other.attachedRigidbody));
                ingredientToAdd.SetOnPlate(true);
            }
        }
    }
}
