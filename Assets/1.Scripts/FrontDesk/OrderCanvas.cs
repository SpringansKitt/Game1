using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class OrderCanvas : MonoBehaviour
{
    public FrontDeskManager frontDeskManager;
    public Customer customer;
    public GameObject speechBubble;
    public TMP_Text scriptText;
    public GameObject acceptButton;
    public GameObject refuseButton;

    public GameObject workShop;
    public GimbabManager gimbabManager;
    public void StartOrder(string script)
    {
        gameObject.SetActive(true);
        StartCoroutine(CoOrder(script));
        acceptButton.SetActive(false);
        refuseButton.SetActive(false);
    }

    IEnumerator CoOrder(string script)
    {
        char[] scripts = script.ToCharArray();
        scriptText.text = "";
        for (int i = 0; i < scripts.Length; i++)
        {
            scriptText.text += scripts[i].ToString();
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.25f);
        acceptButton.SetActive(true);

        yield return new WaitForSeconds(0.25f);
        refuseButton.SetActive(true);
    }

    public void OnClickedAcceptButton()
    {
        acceptButton.SetActive(false);
        gameObject.SetActive(false);
        workShop.SetActive(true);
        gimbabManager.StartWork();
    }
    public void OnClickedRefuseButton()
    {
        customer.gameObject.SetActive(false);
        gameObject.SetActive(false);
        Invoke("BackFrontDesk", 2.0f);
    }

    public void BackFrontDesk()
    {
        frontDeskManager.EnterCustomer();
    }
    //�۾��� �� ��µ� �Ŀ� ��ư�� ���� �� �ְ�
    //��ư�� ������ ��� ����� �����ϱ�
    //�մ��� ���ϴ� �޴�
}