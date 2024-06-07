using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSpotUI : MonoBehaviour
{
    [Header("Building Spot UI")]
    [SerializeField]
    private BuildingSpotBtns _buildingSpotBtns;
    [SerializeField]
    private List<Structure> _lowLvlStructures;

    private void OnEnable()
    {
        DisplayStructures();
    }

    public void PressCloseBtn()
    {
        Destroy(gameObject);
    }

    public void BuildStructure(Structure structure)
    {

    }

    private void DisplayStructures()
    {
        foreach (var structure in _lowLvlStructures)
        {
            GameObject contentElement = Instantiate(_buildingSpotBtns.ContentElement);
            contentElement.transform.SetParent(_buildingSpotBtns.Content.transform);
            contentElement.GetComponent<BuildElementUI>().SetBuildingUIData(null, structure.GetName, structure.GetDescription, structure.GetPrice);

            var btn = contentElement.GetComponent<Button>();
            btn.onClick.AddListener(PressCloseBtn);
            btn.onClick.AddListener(() => BuildStructure(structure));
        }
    }

    [System.Serializable]
    private struct BuildingSpotBtns
    {
        public GameObject Panel;
        public GameObject Content;
        public GameObject ContentElement;
    }
}
