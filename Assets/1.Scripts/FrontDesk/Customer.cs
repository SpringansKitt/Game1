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
        orderCanvas.StartOrder(orderScript);

    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
