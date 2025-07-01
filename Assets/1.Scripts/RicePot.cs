using UnityEngine;

public class RicePot : IngredientContainer
{
    public WorkShop workShop;
    public GameObject RicePrefeb;
    private bool ishold = false;
    private float holdTimer = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverThisObject())
            {
                ishold = true;
                holdTimer = 0f;
            }
        }

        if (ishold && Input.GetMouseButton(0))
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= 1f)
            {
                SpawnPrefeb();
                ishold = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            ishold = false;
            holdTimer = 0f;
        }
    }

    bool IsPointerOverThisObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        return hit.collider != null && hit.collider.gameObject == gameObject;
    }

    public void SpawnPrefeb()
    {
        GameObject laver = Instantiate(RicePrefeb);
        Vector3 screenPos = Input.mousePosition;
        laver.transform.position = Camera.main.ScreenToWorldPoint(screenPos);
        workShop.riceSet = true;
    }
}
