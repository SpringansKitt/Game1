using System.Collections.Generic;
using UnityEngine;

public class IngredientContainer : MonoBehaviour
{
    public IngredientName IngredientName;
    public Ingredient ingredient;
    private bool ishold = false;
    private float holdTimer = 0f;

    public virtual void Down(Vector2 worldPoint)
    {
        ingredient = null;
        ishold = true;
        holdTimer = 0f;
    }
    public virtual void Drag(Vector2 worldPoint)
    {
        Debug.Log("IngredientContainer Drag");
    }
    public virtual void Up(Vector2 worldPoint)
    {
        if (holdTimer <= 0.2f && ishold)
        {
            float random_y = Random.Range(-4f, 0f);
            Ingredient ingredientPrefab = Resources.Load<Ingredient>("Ingredient");
            ingredient = Instantiate(ingredientPrefab);
            ingredient.transform.position = new Vector3(0f, random_y, 0f);
            
            gameObject.GetComponent<Gimbab>().AddIngredient(ingredient);
        }
        ingredient = null;
        ishold = false;
    }

    void Update()
    {
        if (ishold)
        {
            holdTimer += Time.deltaTime;
        }
    }
}



public enum IngredientName
{
    Rice,
    Laver,
    Carrot,
    Egg,
    Ham,
    Spinach,
    Burdock,
    PickledRadish
}
