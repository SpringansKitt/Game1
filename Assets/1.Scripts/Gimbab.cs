using System.Collections.Generic;
using UnityEngine;

public class Gimbab : MonoBehaviour
{
    public List<IngredientName> ingredientNames = new List<IngredientName>();
    public bool rolled;
    

    public void AddIngredient(IngredientName ingredientName)
    {
        ingredientNames.Add(ingredientName);
    }
}
