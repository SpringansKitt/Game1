using TMPro;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    public TMP_Text coinText;
    void Start()
    {
        coinText = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        coinText.text = User.instance.userData.coin.ToString();
    }
}
