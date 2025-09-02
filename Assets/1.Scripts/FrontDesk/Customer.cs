using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string orderScript = "wwwww";
    public GimbabName gimbabName = GimbabName.Gimbab;

    public OrderCanvas orderCanvas;
    public SpeechBubble speechBubble;
    public OrderData orderData;

    public void Enter()
    {
        gameObject.SetActive(true);
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Enter");

        Invoke("StartOrder", Random.Range(0.5f, 1f));

    }

    public void Exit()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Exit");
        StartCoroutine(ExitDisableObject());
    }

    public IEnumerator ExitDisableObject()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    public void TakeGimbab(Gimbab gimbab)
    {
        Debug.Log("");
    }

    public void StartOrder()
    {
        List<OrderData> canOrderlist = OrderManager.instance.GetCanOrderDatas();

        orderData = canOrderlist[Random.Range(0, canOrderlist.Count)];
        string script = orderData.orders[Random.Range(0, orderData.orders.Count)];
        orderCanvas.StartOrder(script);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
