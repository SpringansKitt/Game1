using TMPro;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    public TMP_Text coinText;
    void Start()
    {
        coinText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = User.Instance.coin.ToString();
    }
}
