﻿using System.Collections;
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

    [Space]
    [Header("Map sprites")]
    public Texture2D islandTexture;

    [Space]
    [Header("Decorate map")]
    [Range(0, .9f)]
    public float erodePercent = .5f;
    public int erodeIterations = 2;
    [Range(0, .9f)]
    public float treePercent = .3f;
    [Range(0, .9f)]
    public float hillPercent = .2f;
    [Range(0, .9f)]
    public float mountainsPercent = .1f;

    public Map map;

    // Start is called before the first frame update
    void Start()
    {
        map = new Map();
    }

    public void MakeMap()
    {
        map.NewMap(mapWidth, mapHeight);
        map.CreateIsland(erodePercent, erodeIterations, treePercent, hillPercent, mountainsPercent);
        CreateGrid();
    }

    private void CreateGrid()
    {
        ClearMapContainer();
        Sprite[] sprites = Resources.LoadAll<Sprite>(islandTexture.name);

        var total = map.tiles.Length;
        var maxColumns = map.columns;
        var column = 0;
        var row = 0;

        for (var i = 0; i < total; i++)
        {
            column = i % maxColumns;

            var newX = column * tileSize.x;
            var newY = -row * tileSize.y;

            var go = Instantiate(tilePrefab);
            go.name = "Tile " + i;
            go.transform.SetParent(mapContainer.transform);
            go.transform.position = new Vector3(newX, newY, 0);

            var tile = map.tiles[i];
            var spriteID = tile.autotileID;

            if (spriteID >= 0)
            {
                var sr = go.GetComponent<SpriteRenderer>();
                sr.sprite = sprites[spriteID];
            }
            
            if (column == (maxColumns - 1))
            {
                row++;
            }
        }
    }

    void ClearMapContainer()
    {
        var childern = mapContainer.transform.GetComponentsInChildren<Transform>();
        for (var i = childern.Length-1; i > 0; i--)
        {
            Destroy(childern[i].gameObject);
        }
    }
}
