using UnityEngine;
using UnityEngine.Rendering;

public class Ingredient : MonoBehaviour
{
    public string key;

    public SpriteRenderer spriteRenderer;

    public void Added()
    {
        Gimbab gimbab = transform.GetComponentInParent<Gimbab>();
        spriteRenderer.sortingOrder = gimbab.ingredients.Count;
    }
}
