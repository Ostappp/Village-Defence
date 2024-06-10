using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour, IBuildingObj
{
    private BuildingSpot _buildingSpot;
    private Structure _structure;
    public void Initialize(BuildingSpot buildingSpot, Structure structure)
    {
        Debug.Log($"_buildingSpot pos = {buildingSpot.transform.position}\r\n        _structure = {structure.GetName}");
        _buildingSpot = buildingSpot;
        _structure = structure;
    }

    public void DestroyStructure()
    {
        _buildingSpot.ClearSpot();
        Destroy(gameObject);
    }

    public void UpgradeStructure(Structure upgradedStructure)
    {
        if (_buildingSpot.BuildStructure(upgradedStructure))
            Destroy(gameObject);
        else
        {
            Destroy(GetComponentInChildren<BuildingUI>().gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        var structureUI = Instantiate(_structure.GetUIPrefab);
        structureUI.transform.SetParent(transform);
        structureUI.GetComponent<BuildingUI>().SetStructure(_structure);
        UIManager.Instance.DestroyAllOfTypeExcept(structureUI.GetComponent<BuildingUI>());
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.LogWarning($"Look at structure with pos: {transform.position}");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
