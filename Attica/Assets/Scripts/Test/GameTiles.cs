using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTiles : MonoBehaviour
{
    public static GameTiles instance;

    public Tilemap tileMap;

    public Dictionary<Vector3, WorldTile> tiles;

   private void Awake()
        {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GetWorldTiles();
        }

    private void GetWorldTiles()
    {
        tiles = new Dictionary<Vector3, WorldTile>();

        

        foreach (Vector3Int pos in tileMap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);

            if (!tileMap.HasTile(localPlace)) continue;

            var tile = new WorldTile
            {
                LocalPlace = localPlace,
                WorldLocation = tileMap.CellToWorld(localPlace),
                tileBase = tileMap.GetTile(localPlace),
                TilemapMember = tileMap,
                Name = localPlace.x + "," + localPlace.y,
                Cost = 1
            };

            tiles.Add(tile.WorldLocation, tile);
        }
    }

    }

