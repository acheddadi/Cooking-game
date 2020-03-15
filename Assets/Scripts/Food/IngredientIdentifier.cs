using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfIngredient { RICE, CHICKEN, EGG, SALMON, SHRIMP, SEAWEED, AVOCADO, EMPTY }
public class IngredientIdentifier : MonoBehaviour
{
    [SerializeField] private TypeOfIngredient ingredientType = TypeOfIngredient.RICE;
    [SerializeField] private bool ingredientSource = false;
    private bool onPlate = false;

    public TypeOfIngredient GetFoodType()
    {
        return ingredientType;
    }

    public void SetFoodType(TypeOfIngredient type)
    {
        ingredientType = type;
    }

    public bool GetSource()
    {
        return ingredientSource;
    }

    public void SetOnPlate(bool set)
    {
        onPlate = set;
    }

    public bool GetOnPlate()
    {
        return onPlate;
    }
}
