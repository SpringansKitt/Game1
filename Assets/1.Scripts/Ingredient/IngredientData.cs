using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData", menuName = "Game/IngredientData")]
public class IngredientData : ScriptableObject
{
    public IngredientName ingredientName;
    public Sprite thum;
    public int price;

}
