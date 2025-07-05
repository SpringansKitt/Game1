using System.Collections.Generic;
using UnityEngine;

public class IngredientContainer : MonoBehaviour
{
    public IngredientName IngredientName;

    public virtual void Down(Vector2 worldPoint)
    {
        Debug.Log("IngredientContainer Down");
        GimbabManager.instance.gimbab.AddIngredient(IngredientName);
    }
    public virtual void Drag(Vector2 worldPoint)
    {
        Debug.Log("IngredientContainer Drag");
    }
    public virtual void Up(Vector2 worldPoint)
    {
        Debug.Log("IngredientContainer Up");
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
