using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public GameObject recipePanel;
    public GameObject upgradePanel;
    public GameObject toolPanel;
    public GameObject interiorPanel;
    

    public void OnClickedRecipeButton()
    {
        recipePanel.SetActive(true);
        upgradePanel.SetActive(false);
        toolPanel.SetActive(false);
        interiorPanel.SetActive(false);
    }

    public void OnClickedUpgradeButton()
    {
        recipePanel.SetActive(false);
        upgradePanel.SetActive(true);
        toolPanel.SetActive(false);
        interiorPanel.SetActive(false);
    }

    public void OnClickedToolButton()
    {
        recipePanel.SetActive(false);
        upgradePanel.SetActive(false);
        toolPanel.SetActive(true);
        interiorPanel.SetActive(false);
    }

    public void OnClickedInteriorButton()
    {
        recipePanel.SetActive(false);
        upgradePanel.SetActive(false);
        toolPanel.SetActive(false);
        interiorPanel.SetActive(true);
    }
}
