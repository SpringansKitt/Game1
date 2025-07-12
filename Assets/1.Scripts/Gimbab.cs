using System.Collections.Generic;
using UnityEngine;

public class Gimbab : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    public bool rolled;
    

    public void AddIngredient(Ingredient ingredient)
    {
        ingredient.transform.position = transform.position;
        ingredient.transform.parent = transform;
        ingredients.Add(ingredient);
    }
}
