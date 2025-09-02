using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject shopPanelBackGround;
    public GameObject coinPanel;
    void Start()
    {
        shopPanelBackGround.SetActive(false);
        coinPanel.SetActive(false);
        shopPanel.SetActive(true);
        shopPanel.SetActive(false);
    }
}
