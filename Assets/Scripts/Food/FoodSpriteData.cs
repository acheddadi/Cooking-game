using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FoodSprites", order = 1)]
public class FoodSpriteData : ScriptableObject
{
    [SerializeField] private Sprite[] sprites;
    private static FoodSpriteData instance;
    private FoodSpriteData() { instance = this; }

    public static Sprite GetSprite(int index)
    {
        if (index < instance.sprites.Length && index >= 0) return instance.sprites[index];
        else return null;
    }
}
