using System.Collections.Generic;
using UnityEngine;
using static Values;

[CreateAssetMenu(fileName = "New structure", menuName = "My Assets/Structures")]
public class Structure : ScriptableObject
{
    [Header("Params")]
    [SerializeField] private string Name;
    [SerializeField] private StructureType Type;
    [SerializeField] private GameObject Model;
    
    [Header("Pricing")]
    [SerializeField] private List<Resource> Price;

    [Header("Description")]
    [SerializeField, TextArea] private string Description;


    public string GetName { get => Name; }
    public new StructureType GetType { get => Type; }
    public GameObject GetModel { get => Model; }
    public string GetDescription { get => Description; }

    [System.Serializable]
    public enum StructureType
    {
        None,
        Building,
        Way,
        Resource
    }
}
