using System.Collections.Generic;
using UnityEngine;

public class IngredientContainer : MonoBehaviour
{
    public IngredientName ingredientName;
    public Ingredient ingredient;
    public bool ishold = false;
    public float holdTimer = 0f;


    void Start()
    {
        UserIngredient userIngredient = User.instance.GetUserIngredient(ingredientName.ToString());
        Transform rootTr = transform.Find("Root");
        rootTr.gameObject.SetActive(userIngredient.inPossession);
    }
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
            Ingredient ingredientPrefab = Resources.Load<Ingredient>(ingredientName.ToString());
            ingredient = Instantiate(ingredientPrefab);
            ingredient.transform.position = new Vector3(0f, random_y, 0f);
            //김밥매니저에서 김밥 컴포넌트를 가져오기
            GimbabManager.instance.gimbab.AddIngredient(ingredient);
            //gameObject.GetComponent<Gimbab>().AddIngredient(ingredient); //현재 자신의 오브젝트
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
    CrabStick,
    Spinach,
    Cucumber,
    Burdock,
    PickledRadish,
    Cheeze,
    Tuna,
    SesameLeaf,
    Salad,
    Gimchi,
    ChiliPepper,
    PriedShrimp,
    PorkCutlet,
    KoreanFishCake,
    Bulgogi,
    Mayonnaise,
    Sesame,
    Oil,
    Salt
}
