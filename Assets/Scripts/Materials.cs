using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    public Material material;
    public List<GameObject> materials = new List<GameObject>();
    public WorkShop WorkShop;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverThisObject())
            {
                SpawnPrefeb();
                WorkShop.materialSet = true;
            }
        }
    }

    public void SpawnPrefeb()
    {
        float y_random = Random.Range(0.0f, -4.0f);
        if (material == Material.Material1)
        {
            GameObject material1 = Instantiate(materials[0]);
            material1.transform.position = new Vector3(0, y_random, 0);
        }
        if (material == Material.Material2)
        {
            GameObject material2 = Instantiate(materials[1]);
            material2.transform.position = new Vector3(0, y_random, 0);
        }
        if (material == Material.Material3)
        {
            GameObject material3 = Instantiate(materials[2]);
            material3.transform.position = new Vector3(0, y_random, 0);
        }
    }
    bool IsPointerOverThisObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        return hit.collider != null && hit.collider.gameObject == gameObject;
    }
}

public enum Material
{
    Material1,
    Material2,
    Material3
}
