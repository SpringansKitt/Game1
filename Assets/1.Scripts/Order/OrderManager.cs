using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;
    public OrderData[] orderDatas;

    
    private void Awake()
    {
        instance = this;
        TextAsset textAsset = Resources.Load<TextAsset>("JSON/OrderData");
        string json = textAsset.text;

        JSONObject jObject = JSONObject.Parse(json);
        JSONArray jArray = jObject.GetArray("JSON");
        Debug.Log(jArray.Length);
        orderDatas = new OrderData[jArray.Length];
        for (int i = 0; i < jArray.Length; i++)
        {
            orderDatas[i] = new OrderData();
            orderDatas[i].order1 = jArray[i].Obj.GetString("order1");
            orderDatas[i].order2 = jArray[i].Obj.GetString("order2");
            orderDatas[i].order3 = jArray[i].Obj.GetString("order3");
            orderDatas[i].order4 = jArray[i].Obj.GetString("order4");
            orderDatas[i].order4 = jArray[i].Obj.GetString("order5");


            orderDatas[i].gimbabName = System.Enum.Parse<GimbabName>(jArray[i].Obj.GetString("gimbabName"));

            orderDatas[i].isNude = bool.Parse(jArray[i].Obj.GetString("isNude"));

            string addIngredientsStr = jArray[i].Obj.GetString("addIngredients");
            string[] addIngStrs = addIngredientsStr.Split(',');
            for (int j = 0; j < addIngStrs.Length; j++)
            {
                IngredientName ingredientName = System.Enum.Parse<IngredientName>(addIngStrs[j]);
                orderDatas[i].addIngredients.Add(ingredientName);
            }

            string subtractIngredientsStr = jArray[i].Obj.GetString("subtractIngredients");
            string[] subtractIngStrs = subtractIngredientsStr.Split(',');
            for (int k = 0; k < addIngStrs.Length; k++)
            {
                IngredientName ingredientName = System.Enum.Parse<IngredientName>(subtractIngStrs[k]);
                orderDatas[i].subtractIngredients.Add(ingredientName);
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public List<OrderData> orderDataList = new List<OrderData>();
    public List<OrderData> GetCanOrderDatas()
    {
        orderDataList.Clear();
        for (int i = 0; i < orderDatas.Length; i++)
        {
            UserRecipe userRecipe = User.instance.GetUserRecipe(orderDatas[i].gimbabName.ToString());
            if (userRecipe.inPossession)
            {
                orderDataList.Add(orderDatas[i]);
            }
        }
        return orderDataList;
    }
}
[System.Serializable]
public class OrderData
{
    public string order1;
    public string order2;
    public string order3;
    public string order4;
    public string order5;
    public GimbabName gimbabName;
    public List<IngredientName> addIngredients = new List<IngredientName>();
    public List<IngredientName> subtractIngredients = new List<IngredientName>();
    public bool isNude;
    public float aPayment;
    public float tip;
}