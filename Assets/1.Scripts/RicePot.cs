using UnityEngine;

public class RicePot : IngredientContainer
{
    public GameObject RicePrefeb;

    public override void Down(Vector2 worldPoint)
    {
       
        Debug.Log("RicePot Down");
    }
    public override void Drag(Vector2 worldPoint)
    {
        
        Debug.Log("RicePot Drag");
    }
    public override void Up(Vector2 worldPoint)
    {
        
        Debug.Log("RicePot Up");
    }
}
