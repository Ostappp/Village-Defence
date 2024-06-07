using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Values
{
    public static string GetResourceAmount(IEnumerable<Resource> resources, bool writeZeroValues = false, string prefix = "")
    {
        StringBuilder sb = new();
        foreach (ResourceType resType in Enum.GetValues(typeof(ResourceType)))
        {
            var resCount = resources.Where(r => r.GetType == resType).Sum(r => r.GetCount);
            if (resCount > 0 || (writeZeroValues && resCount == 0))
            {
                sb.AppendLine($"{prefix}{resType}: x{resCount}");
            }
        }

        return sb.ToString();
    }

    public static IEnumerable<Resource> SummarizeResources(IEnumerable<Resource> resources)
    {
        List<Resource> result = new();
        foreach (ResourceType resType in Enum.GetValues(typeof(ResourceType)))
        {
            var resCount = resources.Where(r => r.GetType == resType).Sum(r => r.GetCount);
            result.Add(new Resource(resType, (uint)resCount));
        }

        return result;
    }
    [Serializable]
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
    [Serializable]
    public enum ResourceType
    {
        Water,
        Food,
        Wood,
        Metal,
        Gold,
    }
}


