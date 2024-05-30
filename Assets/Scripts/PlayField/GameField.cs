using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField, Select(typeof(int), new object[] { 2, 3, 5, 10, 16, 32 })]
    int GridSize;
    private void Awake()
    {
        PlayGrid.GenerateGrid(gameObject.transform.position, GridSize).transform.SetParent(transform);
    }
}
