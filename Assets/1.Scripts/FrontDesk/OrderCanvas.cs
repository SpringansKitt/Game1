using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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
        acceptButton.SetActive(false);
        refuseButton.SetActive(false);
        StartCoroutine(CoOrder(script));
    }

    IEnumerator CoOrder(string script)
    {
        char[] scripts = script.ToCharArray();
        scriptText.text = "";

        yield return new WaitForSeconds(0.2f);

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
        gameObject.SetActive(false);
        customer.Exit();
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