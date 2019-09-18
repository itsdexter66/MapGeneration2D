using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapTester : MonoBehaviour
{
    [Header("Map Dimensions")]
    public int mapWidth = 20;
    public int mapHeight = 20;

    [Space]
    [Header("Vizualize map")]
    public GameObject mapContainer;
    public GameObject tilePrefab;
    public Vector2 tileSize = new Vector2(16, 16);

    public Map map;

    // Start is called before the first frame update
    void Start()
    {
        map = new Map();
    }

    public void MakeMap()
    {
        map.NewMap(mapWidth, mapHeight);
        Debug.Log("created a new map" + map.columns + "*" + map.rows);
    }

    private void CreateGrid()
    {
        var total = map.tiles.Length;
        var maxColumns = map.columns;
        var column = 0;
        var row = 0;

        for (var i = 0; i < total; i++)
        {
            column = i % maxColumns;

            var newX = column * tileSize.x;
            var newY = -row * tileSize.y;

            var
        }
    }
}
