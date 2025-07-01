using UnityEngine;

public class WorkShopManager : MonoBehaviour
{
    public Gimbab gimbabPrefeb;
    public Transform cuttingBoardTr;
    void Start()
    {
        StartWork();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //���� ���콺 ��ġ ���� ��ǥ�� ġȯ
            Collider2D[] cols = Physics2D.OverlapPointAll(worldPoint); //���� ��ǥ�� �ش��ϴ� �浹ü ã��
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].CompareTag("Ingredient"))
                {
                    IngredientContainer ingredientContainer = cols[i].GetComponent<IngredientContainer>();
                    //���� Ŭ���� ����� ã�� �ڵ�
                    break;
                }
            }

        }
    }

    public void StartWork()
    {
        Gimbab gimbab = Instantiate(gimbabPrefeb);
        gimbab.transform.position = cuttingBoardTr.position;
    }
}
