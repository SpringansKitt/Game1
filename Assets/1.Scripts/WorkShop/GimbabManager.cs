using UnityEngine;
using UnityEngine.Rendering;

public class GimbabManager : MonoBehaviour
{
    public Gimbab gimbabPrefeb;
    public Transform cuttingBoardTr;
    public static GimbabManager instance;
    public Gimbab gimbab; //씬 상에 생성된 김밥 컴포넌트
    private IngredientContainer ingredientContainer;

    public bool rolling;
    public Transform rollerTr;

    public Transform leftTr;
    public Transform rightTr;

    public Transform workSpaceTr;
    public bool isDragging;
    public Vector2 preWorldPoint;
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
            isDragging = true;
            preWorldPoint = worldPoint;
        }
        else if (Input.GetMouseButton(0)) //누르고 있는 상태면 true  
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (isDragging)
            {
                Vector2 direction = worldPoint - preWorldPoint;
                workSpaceTr.position = new Vector3(workSpaceTr.position.x + direction.x, workSpaceTr.position.y, 0);

                if (workSpaceTr.position.x < leftTr.position.x)
                {
                    workSpaceTr.position = new Vector3(leftTr.position.x, workSpaceTr.position.y, 0);
                }
                else if (workSpaceTr.position.x > rightTr.position.x)
                {
                    workSpaceTr.position = new Vector3(rightTr.position.x, workSpaceTr.position.y, 0);
                }

                preWorldPoint = worldPoint;
            }

            if (ingredientContainer == null)
            {
                return;
                // ingredientContainer.ingredientName -> 재료의 종류!
            }
            ingredientContainer.Drag(worldPoint);
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
        workSpaceTr.transform.position = rightTr.position;
        GameManager gameManager = GameManager.instance;
        gimbab = Instantiate(gimbabPrefeb, workSpaceTr);
        gimbab.transform.position = cuttingBoardTr.position;
        gameManager.endurance = 100.0f;
        gameManager.isOrder = true;
        gameManager.StartDecreaseEndurance();
    }
}
