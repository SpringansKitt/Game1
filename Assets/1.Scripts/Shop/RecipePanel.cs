using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{
    public string key;
    [SerializeField] RecipeData recipeData;

    public TMP_Text nameText;
    public TMP_Text priceText;

    public GameObject purchaseButton;
    public GameObject purchaseImage;
    public GameObject unlockImage;

    public TMP_Text unlockLvText;
    public Image iconImage;


    public void Awake()
    {
        recipeData = Resources.Load<RecipeData>("RecipeData/" + key);
    }

    public void OnEnable()
    {
        UpdatePanel();
    }
    void Start()
    {
        nameText.text = recipeData.recipeName;
        priceText.text = recipeData.price.ToString();
        unlockLvText.text = $"Lv.{recipeData.userLevel} Unlock";
        iconImage.sprite = recipeData.icon;
        UpdatePanel();
    }

    public void UpdatePanel()
    {
        if (User.instance.userData.userLevel < recipeData.userLevel)
        {
            purchaseButton.SetActive(false);
            purchaseImage.SetActive(false);
            unlockImage.SetActive(true);
            nameText.text = "???";
            return;
        }

        else
        {
            nameText.text = recipeData.recipeName;
            UserRecipe userRecipe = User.instance.GetUserRecipe(key);
            if(userRecipe.inPossession)
            {
                purchaseButton.SetActive(false);
                purchaseImage.SetActive(true);
                unlockImage.SetActive(false);
                return;
            }

            else
            {
                purchaseButton.SetActive(true);
                purchaseImage.SetActive(false);
                unlockImage.SetActive(false);
                return;
            }
        }
        
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
        UpdatePanel();
    }
}
