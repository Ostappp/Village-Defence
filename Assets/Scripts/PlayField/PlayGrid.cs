using System.Collections.Generic;
using UnityEngine;

public static class PlayGrid
{
    public const int GRID_SIZE = 32;
    public const int BUILDING_SPOT_SIZE = 2;


    public static GameObject GenerateGrid(Vector3 pos, int gridSize, LayerMask layer)
    {
        //��������� �������
        GameObject plane = GeneratePlane(pos, gridSize);

        //��������� ���������� �����
        plane = SetBuildingSpots(plane, gridSize, layer);

        return plane;
    }
    private static GameObject GeneratePlane(Vector3 pos, int gridSize)
    {
        // ��������� ������ GameObject � Plane
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        // ������� �������
        plane.transform.position = pos;

        // ������� ������
        plane.transform.localScale = new Vector3(gridSize * BUILDING_SPOT_SIZE / 5f, 1, gridSize * BUILDING_SPOT_SIZE / 5f);

        return plane;
    }
    private static GameObject SetBuildingSpots(GameObject plane, int gridSize, LayerMask layer)
    {
        //��������� �������
        Vector3 pos = new(BUILDING_SPOT_SIZE / 2f, 0, BUILDING_SPOT_SIZE / 2f);
        List<GameObject> buildingSpots = new();

        for (int i = 0; i < gridSize; i++, pos.x = BUILDING_SPOT_SIZE / 2f, pos.z += 2 * BUILDING_SPOT_SIZE)
        {
            for (int j = 0; j < gridSize; j++, pos.x += 2 * BUILDING_SPOT_SIZE)
            {
                // ��������� ������ GameObject � Cube
                GameObject buildingSpot = GameObject.CreatePrimitive(PrimitiveType.Cube);

                // ������� �������
                buildingSpot.transform.position = pos;

                // ������� ������
                buildingSpot.transform.localScale = new Vector3(BUILDING_SPOT_SIZE, 1, BUILDING_SPOT_SIZE);

                // ������� ������������ �����
                buildingSpot.transform.SetParent(plane.transform, true);

                // ������������ LayerMask �� ����� ����
                int layerNumber = layer.value == -1 ? 0 : (int)Mathf.Log(layer.value, 2);

                // ����� ����� �������� �������� ����� ����
                buildingSpot.layer = layerNumber;


                buildingSpots.Add(buildingSpot); 
            }
            
        }
        //����������� ���������� �������
        pos = new Vector3(buildingSpots[0].transform.localPosition.x + buildingSpots[^1].transform.localPosition.x, 
            0, buildingSpots[0].transform.localPosition.z + buildingSpots[^1].transform.localPosition.z) / 2f;
        
        //���� ����� �� ����� �������� ���� �� ������������ ������� �� ���
        foreach (var buildingSpot in buildingSpots)
        {
            buildingSpot.transform.localPosition -= pos;
            buildingSpot.AddComponent<BuildingSpot>();
        }
        return plane;
    }


}
