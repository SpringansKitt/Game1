using TMPro;
using UnityEngine;

public class ApPanel : MonoBehaviour
{
    public TMP_Text apText;
    void Start()
    {
        apText = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        apText.text = GameManager.instance.currentap.ToString() + " / " + GameManager.instance.maxAp.ToString();
    }
}
