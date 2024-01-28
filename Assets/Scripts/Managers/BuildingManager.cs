using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private Material wrongMaterial;
    [SerializeField] private Material correctMaterial;
    [SerializeField] private LayerMask layerMask;

    private GameObject currentObject;
    private RaycastHit hit;
    private bool isPlacing = false;

    public bool canPlace;

    private void Update()
    {
        if (currentObject != null)
        {
            if (isPlacing)
            {
                if (canPlace && Input.GetMouseButtonDown(0))
                {
                    PlaceObject();
                }
                else
                {
                    UpdateMaterial();
                    MoveObjectWithMouse();
                }
            }
            else
            {
                MoveObjectWithMouse();
            }
        }
    }  
    public void StartPlacing(int index)
    {
        if (currentObject != null)
        {
            Destroy(currentObject);
        }
        currentObject = Instantiate(objects[index]);
        isPlacing = true;
    }

    private void UpdateMaterial()
    {
        currentObject.GetComponent<MeshRenderer>().material = canPlace ? correctMaterial : wrongMaterial;
    }

    private void MoveObjectWithMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            currentObject.transform.position = hit.point;
        }
    }

    private void PlaceObject()
    {
        isPlacing = false;
        currentObject = null;
    }

  
}
