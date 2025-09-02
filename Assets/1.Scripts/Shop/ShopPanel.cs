using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public Animator shopAnimator;
    public GameObject shopPanelBackGround;
    public GameObject coinPanel;

    public bool isShow;

    public GameObject recipePanel;
    public GameObject upgradePanel;
    public GameObject toolPanel;
    public GameObject interiorPanel;

    void Awake()
    {
        shopAnimator = this.GetComponent<Animator>();
    }
    void Start()
    {
        isShow = false;
    }

    public void OnClickedShopButton()
    {
        gameObject.SetActive(true);
        OnClickedRecipeButton();
        shopPanelBackGround.SetActive(true);
        coinPanel.SetActive(true);
        shopAnimator.SetTrigger("doShow");
        isShow = true;
     }
    
    public void OnClickedShopExitButton()
    {
        shopPanelBackGround.SetActive(false);
        coinPanel.SetActive(false);
        shopAnimator.SetTrigger("doHide");
        isShow = false;
        StartCoroutine(CoAfterHide());
    }


    public IEnumerator CoAfterHide()
    {
        yield return null;
        yield return new WaitForSeconds(shopAnimator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);

    }

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
