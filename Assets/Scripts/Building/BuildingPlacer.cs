using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlacer : MonoBehaviour
{
    public static BuildingPlacer instance;

    public LayerMask groundLayerMask;

    private GameObject _buildingPrefab;
    private GameObject _toBuild;

    private Camera _mainCamera;
    private bool _isPlacingBuilding = false;

    private void Awake()
    {
        instance = this;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_isPlacingBuilding)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return;
            }

            Ray ray = _mainCamera.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, groundLayerMask))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (_toBuild == null && _buildingPrefab != null) // Sprawdü, czy _buildingPrefab nie jest null
                    {
                        _PrepareBuilding(hit.point);
                    }
                }
                else if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && _toBuild != null) // Dodano sprawdzenie _toBuild
                {
                    _toBuild.transform.position = hit.point;
                }
                else if (touch.phase == TouchPhase.Ended && _toBuild != null) // Dodano sprawdzenie _toBuild
                {
                    BuildingValidate validator = _toBuild.GetComponent<BuildingValidate>();
                    if (validator != null && validator.hasValidPlacement)
                    {
                        validator.SetPlacementMode(PlacementMode.Fixed);
                        _isPlacingBuilding = false;
                        _toBuild = null;
                        _buildingPrefab = null;
                    }
                    else
                    {
                        Destroy(_toBuild);
                        _isPlacingBuilding = false;
                        _toBuild = null;
                        _buildingPrefab = null;
                    }
                }
            }
        }
    }
    private void _PrepareBuilding(Vector3 position)
    {
        _toBuild = Instantiate(_buildingPrefab, position, Quaternion.identity);

        BuildingValidate validator = _toBuild.GetComponent<BuildingValidate>();
        if (validator != null)
        {
            validator.isFixed = false;
            validator.SetPlacementMode(PlacementMode.Valid);
        }
    }

    public void SetBuildingPrefab(GameObject prefab)
    {
        _buildingPrefab = prefab;
        _isPlacingBuilding = true;
    }

    
}