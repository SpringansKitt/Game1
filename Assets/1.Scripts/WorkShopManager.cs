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
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //현재 마우스 위치 월드 좌표로 치환
            Collider2D[] cols = Physics2D.OverlapPointAll(worldPoint); //현재 좌표에 해당하는 충돌체 찾기
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].CompareTag("Ingredient"))
                {
                    IngredientContainer ingredientContainer = cols[i].GetComponent<IngredientContainer>();
                    //현재 클릭한 재료통 찾는 코드
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
