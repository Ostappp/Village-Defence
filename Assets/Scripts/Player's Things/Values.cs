using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values
{
    [System.Serializable]
    public struct Resource
    {
        [SerializeField] private ResourceType Type;
        [SerializeField] private uint Count;

        public new readonly ResourceType GetType { get => Type; }
        public readonly uint GetCount { get => Count; }
        public Resource(ResourceType type, uint count = 0)
        {
            Type = type;
            Count = count;
        }

        public void IncreaseResource(uint amount) => Count += amount;
        public bool DecreaseResource(uint amount)
        {
            if (Count < amount) return false;

            Count -= amount;
            return true;
        }
        public uint GetResource(uint amount)
        {
            if (Count > amount)
            {
                Count -= amount;
                return amount;
            }
            else
            {
                Count = 0;
                return Count;
            }
        }
    }
    [System.Serializable]
    public enum ResourceType
    {
        Water,
        Food,
        Wood,
        Metal,
        Gold,
    }
}


