using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSpot : MonoBehaviour, IBuildingObj
{
    private SpotState _spotState;
    private Structure _structure;
    private BuildingSpot _mainSpot;

    [SerializeField]
    private List<Structure> _firstLvlBuilds;
    [SerializeField] 
    private BuildingUI _buildingUIPrefab;
    
    public void ClearSpot()
    {
        _spotState = SpotState.Empty;
        _structure = null;
        _mainSpot = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Pointer clics at building spot. Spot pos: {transform.position}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log($"Pointer downs at building spot. Spot pos: {transform.position}");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"Pointer looks at building spot. Spot pos: {transform.position}");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public enum SpotState
    {
        Empty,
        HasStructure
    }
}
