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
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //���� ���콺 ��ġ ���� ��ǥ�� ġȯ
            Collider2D[] cols = Physics2D.OverlapPointAll(worldPoint); //���� ��ǥ�� �ش��ϴ� �浹ü ã��
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
        else if (Input.GetMouseButton(0)) //������ �ִ� ���¸� true  
        {
            if (ingredientContainer == null)
                return;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ingredientContainer.Drag(worldPoint);
            // ingredientContainer.ingredientName -> ����� ����!
        }
        else if (Input.GetMouseButtonUp(0)) //�� �������� �� 
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
