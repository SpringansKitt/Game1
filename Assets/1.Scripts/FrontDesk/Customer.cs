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
        orderCanvas.StartOrder(orderScript);
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
