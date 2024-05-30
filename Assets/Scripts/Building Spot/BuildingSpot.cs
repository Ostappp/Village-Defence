using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpot : MonoBehaviour
{
    private SpotState _spotState;
    
    public void ClearSpot()
    {
        _spotState = SpotState.Empty;
    }

    public enum SpotState
    {
        Empty,
        HasStructure
    }
}
