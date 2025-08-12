using UnityEngine;

[CreateAssetMenu(fileName = "RecipeData", menuName = "Game/RecipeData")]
public class RecipeData : ScriptableObject
{
    public string recipeName;
    public string key;
    public int userLevel;
    public GimbabName[] gimbabNames;
    public int price;
    public Sprite icon;

    public IngredientName[] ingredientNames;
}
