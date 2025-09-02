using UnityEngine;

public class GimbabManager : MonoBehaviour
{
    public Gimbab gimbabPrefeb;
    public Transform cuttingBoardTr;
    public static GimbabManager instance;
    public Gimbab gimbab; //씬 상에 생성된 김밥 컴포넌트
    private IngredientContainer ingredientContainer;

    public bool rolling;
    public Transform rollerTr;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    private void Update()
    {
        if (rolling && Input.GetMouseButtonUp(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (worldPoint.y >= rollerTr.position.y)
            {
                gimbab.rolled = true;
                Debug.Log("김밥완성");
            }
            rolling = false;
            return;
        }



        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //현재 마우스 위치 월드 좌표로 치환

            Collider2D rollerCol = Physics2D.OverlapPoint(worldPoint, LayerMask.GetMask("Roller"));

            if (rollerCol != null && gimbab.rolled == false)
            {
                rolling = true;
                return;
            }
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
        GameManager gameManager = GameManager.instance;
        gimbab = Instantiate(gimbabPrefeb);
        gimbab.transform.position = cuttingBoardTr.position;
        gameManager.endurance = 100.0f;
        gameManager.isOrder = true;
        gameManager.StartDecreaseEndurance();
    }
}
