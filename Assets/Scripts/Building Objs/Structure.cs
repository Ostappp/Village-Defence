using System.Collections.Generic;
using UnityEngine;
using static Values;

[CreateAssetMenu(fileName = "New structure", menuName = "My Assets/Structures")]
public class Structure : ScriptableObject
{
    [Header("Params")]
    [SerializeField] private string _name;
    [SerializeField] private StructureType _type;
    [SerializeField] private GameObject _model;

    [Header("Pricing")]
    [SerializeField] private List<Resource> _price;
    [SerializeField] private List<Resource> _resourcesAfterDestruction;

    [Header("Description")]
    [SerializeField, TextArea] private string _description;

    [Header("Upgrading")]
    [SerializeField] private Structure _nextUpgrade;


    public string GetName { get => _name; }
    public new StructureType GetType { get => _type; }
    public GameObject GetModel { get => _model; }
    public IEnumerable<Resource> GetPrice { get => SummarizeResources(_price); }
    public IEnumerable<Resource> GetDestructionCompensation { get => SummarizeResources(_resourcesAfterDestruction); }
    public string GetDescription { get => _description; }
    public Structure GetUpgradeData { get => _nextUpgrade; }

    [System.Serializable]
    public enum StructureType
    {
        None,
        Building,
        Way,
        Resource
    }
}
