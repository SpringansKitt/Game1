using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class User : MonoBehaviour
{
    public static User instance;

    public TMP_Text userNameText;  //������ ǥ��
    public TMP_Text userLevelText; //�������� ǥ��
    public TMP_Text userExpText;  //���� ���� ����ġ ǥ��

    public UserData userData; // ����



    //���� �� ����������
    public float maxExp;
    public float remainExp;
    public string ingKey;
    public int count;
    public bool isHave;

    void Awake()
    {
        instance = this;

        userData = SaveManager.LoadData<UserData>("UserData");
        if (userData == null)
        {
            userData = new UserData();
            userData.coin = 1000;
            userData.userName = "";
            userData.userLevel = 1;
            userData.userExp = 0f;
            SaveManager.SaveData("UserData", userData);
        }
    }
    void Start()
    {


        maxExp = 0f + Mathf.Pow(100, userData.userLevel);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UserIngredient userIngredient = new UserIngredient();
            userIngredient.key = ingKey;
            userIngredient.count = count;
            userIngredient.inPossession = isHave;
            userData.userIngredients.Add(userIngredient);
            SaveManager.SaveData("UserData", userData);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            AddIngredient("���", 10, true);
        }
    }

    public void AddIngredient(string ingKey, int count, bool ishave)
    {
        //�Ű����� ingKey,count�� ���� ���� ��� ������ �����ϰ� ó���ϱ�
    }

    public void AddCoin()
    {
        userData.coin += 1;
        SaveManager.SaveData("UserData", userData);
    }

    public void AddLevel()
    {
        remainExp = userData.userExp - (0f + Mathf.Pow(100, userData.userLevel - 1));
        userData.userLevel += 1;
        userData.userExp = remainExp;
        remainExp = 0f;

        GameManager gameManager = GameManager.instance;
        gameManager.maxAp = 100 + 10 * userData.userLevel;
        gameManager.currentap += 10;

        SaveManager.SaveData("UserData", userData);
        userLevelText.text = userData.userLevel.ToString();
    }
}


[System.Serializable]
public class UserData
{
    public int coin;
    public List<UserIngredient> userIngredients = new List<UserIngredient>();
    public string userName;
    public int userLevel;
    public float userExp;
}


[System.Serializable]
public class UserIngredient
{
    public string key;
    public int count;
    public bool inPossession;
}