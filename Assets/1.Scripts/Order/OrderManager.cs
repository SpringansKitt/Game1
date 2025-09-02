using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;
    public OrderData[] orderDatas;

    
    void Awake()
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
            orderDatas[i].orders.Add(jArray[i].Obj.GetString("order1"));

            if (string.IsNullOrEmpty(jArray[i].Obj.GetString("order2")) == false)
            {
                orderDatas[i].orders.Add(jArray[i].Obj.GetString("order2"));
            }

            if (string.IsNullOrEmpty(jArray[i].Obj.GetString("order3")) == false)
            {
                orderDatas[i].orders.Add(jArray[i].Obj.GetString("order3"));
            }
            if (string.IsNullOrEmpty(jArray[i].Obj.GetString("order4")) == false)
            {
                orderDatas[i].orders.Add(jArray[i].Obj.GetString("order4"));
            }

     
            orderDatas[i].gimbabName = System.Enum.Parse<GimbabName>(jArray[i].Obj.GetString("gimbabName"));

            orderDatas[i].isNude = bool.Parse(jArray[i].Obj.GetString("isNude"));

            string addIngredientsStr = jArray[i].Obj.GetString("addIngredients");

            if (string.IsNullOrEmpty(addIngredientsStr) == false)
            {
                string[] addIngStrs = addIngredientsStr.Split(',');
                for (int j = 0; j < addIngStrs.Length; j++)
                {
                    IngredientName ingredientName = System.Enum.Parse<IngredientName>(addIngStrs[j]);
                    orderDatas[i].addIngredients.Add(ingredientName);
                }
            }

            string subtractIngredientsStr = jArray[i].Obj.GetString("subtractIngredients");

            if (string.IsNullOrEmpty(subtractIngredientsStr) == false)
            {
                string[] subtractIngStrs = subtractIngredientsStr.Split(',');
                for (int k = 0; k < subtractIngStrs.Length; k++)
                {
                    IngredientName ingredientName = System.Enum.Parse<IngredientName>(subtractIngStrs[k]);
                    orderDatas[i].subtractIngredients.Add(ingredientName);
                }
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
    public List<string> orders = new List<string>();
    public GimbabName gimbabName;
    public List<IngredientName> addIngredients = new List<IngredientName>();
    public List<IngredientName> subtractIngredients = new List<IngredientName>();
    public bool isNude;
    public float aPayment;
    public float tip;
}