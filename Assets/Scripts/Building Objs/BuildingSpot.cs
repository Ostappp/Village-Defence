using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSpot : MonoBehaviour, IBuildingObj
{
    private SpotState _spotState;
    
    public void ClearSpot()
    {
        _spotState = SpotState.Empty;
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
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public enum SpotState
    {
        Empty,
        HasStructure
    }
}
