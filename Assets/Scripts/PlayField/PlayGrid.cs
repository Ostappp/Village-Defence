using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayGrid
{
    public const int GRID_SIZE = 32;
    public const int BUILDING_SPOT_SIZE = 2;


    public static GameObject GenerateGrid(Vector3 pos, int gridSize)
    {
        //Створення площини
        GameObject plane = GeneratePlane(pos, gridSize);

        //Розміщення будівельних блоків
        plane = SetBuildingSpots(plane, gridSize);

        return plane;
    }
    private static GameObject GeneratePlane(Vector3 pos, int gridSize)
    {
        // Створення нового GameObject з Plane
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        // Задання позиції
        plane.transform.position = pos;

        // Задання розмірів
        plane.transform.localScale = new Vector3(gridSize * BUILDING_SPOT_SIZE / 5f, 1, gridSize * BUILDING_SPOT_SIZE / 5f);

        return plane;
    }
    private static GameObject SetBuildingSpots(GameObject plane, int gridSize)
    {
        //Початкова позиція
        Vector3 pos = new(BUILDING_SPOT_SIZE / 2f, 0, BUILDING_SPOT_SIZE / 2f);
        List<GameObject> buildingSpots = new();

        for (int i = 0; i < gridSize; i++, pos.x = BUILDING_SPOT_SIZE / 2f, pos.z += 2 * BUILDING_SPOT_SIZE)
        {
            for (int j = 0; j < gridSize; j++, pos.x += 2 * BUILDING_SPOT_SIZE)
            {
                // Створення нового GameObject з Cube
                GameObject buildingSpot = GameObject.CreatePrimitive(PrimitiveType.Cube);

                // Задання позиції
                buildingSpot.transform.position = pos;

                // Задання розмірів
                buildingSpot.transform.localScale = new Vector3(BUILDING_SPOT_SIZE, 1, BUILDING_SPOT_SIZE);

                // Задання батьківського обєкта
                buildingSpot.transform.SetParent(plane.transform, true);
                buildingSpots.Add(buildingSpot); 
            }
            
        }
        //Знаходження центральної точккки
        pos = new Vector3(buildingSpots[0].transform.localPosition.x + buildingSpots[^1].transform.localPosition.x, 
            0, buildingSpots[0].transform.localPosition.z + buildingSpots[^1].transform.localPosition.z) / 2f;
        
        //зсув обєктів до лівого нижнього кута
        foreach (var buildingSpot in buildingSpots)
        {
            buildingSpot.transform.localPosition -= pos;
        }
        return plane;
    }


}
