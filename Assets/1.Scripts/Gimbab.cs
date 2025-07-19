using System.Collections.Generic;
using UnityEngine;

public class Gimbab : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    public bool rolled;

    
    public void AddIngredient(Ingredient ingredient)
    {
        User user = User.instance;
        ingredient.transform.position = transform.position;
        ingredient.transform.parent = transform;
        ingredients.Add(ingredient);
        user.AddCoin();
        ChangeTransform(ingredient);
    }

    public void ChangeTransform(Ingredient ingredient)
    {
        if (true)
        {
            float random_y = Random.Range(-3.5f, -0.5f);
            ingredient.transform.position = new Vector3(0f, random_y, 0f);
        }
    }
}
