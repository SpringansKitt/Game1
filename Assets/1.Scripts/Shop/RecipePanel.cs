using TMPro;
using UnityEngine;

public class RecipePanel : MonoBehaviour
{
    public string key;
    [SerializeField] RecipeData recipeData;

    public TMP_Text nameText;
    public TMP_Text priceText;

    void Start()
    {
        recipeData = Resources.Load<RecipeData>("RecipeData/" +  key);
        nameText.text = recipeData.recipeName;
        priceText.text = recipeData.price.ToString();

        if (User.instance.userData.userLevel < recipeData.userLevel)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickedPurchased()
    {
        if(User.instance.userData.coin < recipeData.price)
        {
            Debug.Log("µ· ºÎÁ·");
            return;
        }

        User.instance.AddCoin(-recipeData.price);
        for(int i = 0; i < recipeData.ingredientNames.Length; i++)
        {
            User.instance.AddIngredient(recipeData.ingredientNames[i].ToString());
        }

        User.instance.AddRecipe(recipeData.key);
    }
}
