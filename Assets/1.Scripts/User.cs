using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class User : MonoBehaviour
{
    public static User Instance;
    public int coin;
    public TMP_Text coinText;
    public float endurance;
    public TMP_Text enduranceText;
    public int currentap;
    public TMP_Text apText;
    public bool isOrder = false;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        coin = 1000;
        coinText.text = coin.ToString();
    }

    
    void Update()
    {
        
    }

    public void AddCoin()
    {
        coin += 1;
        coinText.text = coin.ToString();
    }

    public void StartDecreaseEndurance()
    {
        StartCoroutine(EnduranceCount());
    }

    public IEnumerator EnduranceCount()
    {

        while (endurance > 0 && isOrder)
        {
            endurance -= 1.0f;
            enduranceText.text = endurance.ToString() + "%";

            if (endurance < 0)
            {
                endurance = 0;
            }

            if (endurance == 0)
            {
                isOrder = false;
                break;
            }

            yield return new
                WaitForSeconds(1.5f);
        }
    }

    public void UseAp()
    {
        currentap -= 1;
        apText.text = currentap.ToString();
    }
}
