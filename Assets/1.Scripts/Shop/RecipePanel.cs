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
        recipeData = Resources.Load<RecipeData>("Recipe/" +  key);
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

    }
}
