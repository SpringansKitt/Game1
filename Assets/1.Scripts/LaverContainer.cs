using UnityEngine;

public class LaverContainer: IngredientContainer
{
    public GameObject laverPrefeb;
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
    }

    public override void Up(Vector2 worldPoint)
    {
        ishold = false;
    }
    void Update()
    {
        if (ishold)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ingredient.transform.position = worldPoint;

            if (Input.GetMouseButtonUp(0))
            {
                Collider2D[] cols = Physics2D.OverlapPointAll(worldPoint);
                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].gameObject.tag == "Gimbab")
                    {
                        //±è¹ä¿¡ ÇöÀç Àç·á ³Ö±â
                        cols[i].gameObject.GetComponent<Gimbab>().AddIngredient(IngredientName);

                        Destroy(ingredient);
                        ishold = false;
                        return;
                    }
                }
            }
        }


        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (true)
        //    {
        //        ishold = true;
        //        holdTimer = 0f;
        //    }
        //}

        //if (ishold && Input.GetMouseButton(0))
        //{
        //    holdTimer += Time.deltaTime;
        //    if (holdTimer >= 1f)
        //    {
        //        ishold = false;
        //    }
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    ishold = false;
        //    holdTimer = 0f;
        //}
    }
}
