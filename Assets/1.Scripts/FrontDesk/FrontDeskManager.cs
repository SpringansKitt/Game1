using UnityEngine;

public class FrontDeskManager : MonoBehaviour
{
    public GameObject frontDesk;
    public GameObject workShop;
    public Customer customer;
    public SpeechBubble speechBubble;
    void Start()
    {
        customer.gameObject.SetActive(false);
        EnterCustomer();
    }

    public void EnterCustomer()
    {
        customer.Enter();
    }
}
