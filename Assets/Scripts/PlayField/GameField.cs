using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField, Select(typeof(int), new object[] { 2, 3, 5, 10, 16, 32 })]
    int GridSize;
    [SerializeField]
    private LayerMask _layer;
    private void Awake()
    {
        PlayGrid.GenerateGrid(gameObject.transform.position, GridSize,_layer).transform.SetParent(transform);
    }
}
