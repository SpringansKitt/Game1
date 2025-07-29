using TMPro;
using UnityEngine;

public class EndurancePanel : MonoBehaviour
{
    public TMP_Text enduranceText;
    void Start()
    {
        enduranceText = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        enduranceText.text = GameManager.instance.endurance.ToString() + "%";
    }
}
