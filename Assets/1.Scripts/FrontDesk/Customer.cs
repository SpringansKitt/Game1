using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string orderScript = "wwwww";
    public GimbabName gimbabName = GimbabName.Gimbab;

    public OrderCanvas orderCanvas;
    public SpeechBubble speechBubble;

    public void Enter()
    {
        gameObject.SetActive(true);

        Invoke("StartOrder", Random.Range(2f, 3f));

    }

    public void StartOrder()
    {
        List<OrderData> canOrderlist = OrderManager.instance.GetCanOrderDatas();

        OrderData orderData = canOrderlist[Random.Range(0, canOrderlist.Count)];
        //string script = orderData.orders[Random.Range(0, orderData.orders.Length)];
        string script = "q";

        orderCanvas.StartOrder(script);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
