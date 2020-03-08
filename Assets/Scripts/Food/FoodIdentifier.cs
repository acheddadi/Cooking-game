using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfFood { SUSHI, SASHIMI, YAKITORI, TEMPURA, EDAMAME, EMPTY }
public class FoodIdentifier : MonoBehaviour
{
    [SerializeField] private TypeOfFood foodType = TypeOfFood.EMPTY;

    public TypeOfFood GetFoodType()
    {
        return foodType;
    }
}
