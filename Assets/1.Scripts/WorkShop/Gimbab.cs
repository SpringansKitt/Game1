using System.Collections.Generic;
using UnityEngine;

public class Gimbab : MonoBehaviour
{
    public List<Ingredient> ingredients = new List<Ingredient>();
    public bool rolled;

    public Transform GimbabTopTr;
    public Transform GimbabBottomTr;

    public void AddIngredient(Ingredient ingredient)
    {
        if (rolled)
        {
            return;
        }
        User user = User.instance;
        ingredient.transform.position = transform.position;
        ingredient.transform.parent = transform;
        ingredient.Added();
        ingredients.Add(ingredient);
        IngredientData data = Resources.Load<IngredientData>("IngredientData/" + ingredient.key);
        user.AddCoin(-data.price);
        ChangeTransform(ingredient);
    }

    public void ChangeTransform(Ingredient ingredient)
    {
        if (true)
        {
            float random_y = Random.Range(GimbabBottomTr.position.y, GimbabTopTr.position.y);
            ingredient.transform.position = new Vector3(transform.position.x, random_y, 0f);
        }
    }
}
