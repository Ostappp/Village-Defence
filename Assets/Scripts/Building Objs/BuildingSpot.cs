using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSpot : MonoBehaviour, IBuildingObj
{
    private Structure _structure;
    //when building is done it may need more than oine building spot. So there is placing the spots that will be covered by building.
    private List<BuildingSpot> _coveredSpots;

    [SerializeField]
    private GameObject _buildingUIPrefab;

    private float _spotDistance;
    private void Awake()
    {
        CalculateSpotDistance();
    }
    public void ClearSpot()
    {
        gameObject.SetActive(true);
        _structure = null;
        foreach (var spot in _coveredSpots)
        {
            spot.gameObject.SetActive(true);
        }
        _coveredSpots = new List<BuildingSpot>();
    }
    
    private bool HideSpots(Vector2Int buildingSize)
    {
        _coveredSpots = new List<BuildingSpot>();

        Vector3 startGridPosition = transform.position;

        // find others BuildingSpot
        for (int y = 0; y < buildingSize.y; y++)
        {
            for (int x = 0; x < buildingSize.x; x++)
            {
                Vector3 searchPosition = startGridPosition + new Vector3(x * _spotDistance, 0, y * _spotDistance);
                BuildingSpot spot = FindSpotAtPosition(searchPosition);
                if (spot != null && spot != this) // check if it is not current BuildingSpot
                {
                    _coveredSpots.Add(spot);                     
                }
            }
        }
        if(_coveredSpots.Count + 1 == (buildingSize.x * buildingSize.y))
        {
            foreach (var item in _coveredSpots)
            {
                item.gameObject.SetActive(false);
            }
            return true;
        }
            
        return false;
    }

    private void CalculateSpotDistance()
    {
        BuildingSpot[] allSpots = FindObjectsOfType<BuildingSpot>();
        float minDistance = float.MaxValue;

        foreach (BuildingSpot spot in allSpots)
        {
            if (spot != this)
            {
                float distance = Vector3.Distance(transform.position, spot.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
        }
        _spotDistance = minDistance;
        Debug.LogError(_spotDistance);
    }
    private BuildingSpot FindSpotAtPosition(Vector3 worldPosition)
    {
        Ray ray = new(worldPosition + Vector3.up * 1000, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 1200) && hit.transform.GetComponent<BuildingSpot>() != null)
        {
            return hit.transform.GetComponent<BuildingSpot>();
        }
        return null;
    }

    public bool BuildStructure(Structure structure)
    {
        if(_structure != null)
        {
            if (_structure.GetStructureSize == structure.GetStructureSize)
            {
                CreateNewStructure(structure);
                return true;
            }
            else
                Debug.Log("New structure has different size comparing to existing one");
        }
        else
        {
            if (HideSpots(structure.GetStructureSize))
            {
                CreateNewStructure(structure);
                return true;
            }
            else
                Debug.LogWarning("Not enough space");
        }

        return false;
    }

    private void CreateNewStructure(Structure structure)
    {
        _structure = structure;
        var building = Instantiate(_structure.GetPrefab);
        building.transform.position = CalculateClusterCenter();
        building.layer = gameObject.layer;
        building.AddComponent<Building>().Initialize(this, _structure);
        if (!building.TryGetComponent(out Collider collider))
        {
            building.AddComponent<BoxCollider>();
        }
        gameObject.SetActive(false);
    }

    private Vector3 CalculateClusterCenter()
    {
        Vector3 sumOfPositions = transform.position; // Починаємо з позиції поточного BuildingSpot
        foreach (BuildingSpot spot in _coveredSpots)
        {
            sumOfPositions += spot.transform.position; // Додаємо позиції покритих спотів
        }
        Debug.Log($"{transform.position} + {string.Join(" + ",_coveredSpots.Select(s=>s.transform.position))}" +
            $"\nsumOfPositions / (_coveredSpots.Count + 1): {sumOfPositions / (_coveredSpots.Count + 1)}");
        return sumOfPositions / (_coveredSpots.Count + 1); // Ділимо на загальну кількість спотів
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var buildingSpotUI = Instantiate(_buildingUIPrefab);
        buildingSpotUI.transform.SetParent(transform);
        UIManager.Instance.DestroyAllOfTypeExcept(buildingSpotUI.GetComponent<BuildingSpotUI>());
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
