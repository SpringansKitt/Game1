using UnityEngine;

public class LaverContainer: IngredientContainer
{
    public override void Down(Vector2 worldPoint)
    {
        ingredient = null;
        ishold = true;
        holdTimer = 0f;
    }

    public override void Up(Vector2 worldPoint)
    {
        if (ingredient != null)
        {
            Collider2D[] cols = Physics2D.OverlapPointAll(worldPoint);
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].gameObject.tag == "Gimbab")
                {
                    //±è¹ä¿¡ ÇöÀç Àç·á ³Ö±â
                    cols[i].gameObject.GetComponent<Gimbab>().AddIngredient(ingredient);

                    ingredient = null;
                    ishold = false;
                    return;
                }
            }
            Destroy(ingredient.gameObject);
        }
        ingredient = null;
        ishold = false;
        holdTimer = 0f;
    }
    void Update()
    {
        if (ishold)
        {
            holdTimer += Time.deltaTime;
        }

        if (holdTimer >= 0.25f && ingredient == null && ishold)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ingredient ingredientPrefab = Resources.Load<Ingredient>(ingredientName.ToString());
            ingredient = Instantiate(ingredientPrefab);
            ingredient.transform.position = worldPoint;
        }

        if (ishold && ingredient != null)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ingredient.transform.position = worldPoint;
        }
    }
}
