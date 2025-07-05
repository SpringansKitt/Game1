using UnityEngine;

public class GimbabManager : MonoBehaviour
{
    public Gimbab gimbabPrefeb;
    public Transform cuttingBoardTr;
    public static GimbabManager instance;
    public Gimbab gimbab;
    private IngredientContainer ingredientContainer;

    public void Awake()
    {
        instance = this;
    }
    private void Start()
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
                    ingredientContainer = cols[i].GetComponent<IngredientContainer>();
                    ingredientContainer.Down(worldPoint);
                    break;
                }
            }
        }
        else if (Input.GetMouseButton(0)) //누르고 있는 상태면 true  
        {
            if (ingredientContainer == null)
                return;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ingredientContainer.Drag(worldPoint);
            // ingredientContainer.ingredientName -> 재료의 종류!
        }
        else if (Input.GetMouseButtonUp(0)) //딱 떨어졌을 때 
        {
            if (ingredientContainer == null)
                return;
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ingredientContainer.Up(worldPoint);
                ingredientContainer = null;
        }
    }

    public void StartWork()
    {
        gimbab = Instantiate(gimbabPrefeb);
        gimbab.transform.position = cuttingBoardTr.position;
    }
}
