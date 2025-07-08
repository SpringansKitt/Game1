using UnityEngine;

public class RicePot : IngredientContainer
{
    public GameObject RicePrefeb;
    private bool ishold = false;
    private float holdTimer = 0f;
    private float holdTime = 0f;
    public Ingredient ingredient;

    public override void Down(Vector2 worldPoint)
    {
        Ingredient ingredientPrefab = Resources.Load<Ingredient>("Ingredient");
        ingredient = Instantiate(ingredientPrefab);
        ingredient.transform.position = worldPoint;
        ishold = true;
        holdTimer = 0f;
    }

    public override void Up(Vector2 worldPoint)
    {
        ishold = false;
    }
}
