using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UserData userData;


    public float endurance;
    public bool isOrder = false;

    public int maxAp;
    public int currentap;

    void Awake()
    {
        instance = this;

        userData = SaveManager.LoadData<UserData>("UserData");
    }

    void Start()
    {
        maxAp = 100 + 10 * (userData.userLevel -1);
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
    }
}
