using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickOnTileTest : MonoBehaviour
{

    private WorldTile _tile;

    

    //public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

            var worldPoint = new Vector3Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y), 0);

           // target.transform.position = worldPoint;

            var tiles = GameTiles.instance.tiles;

            if (tiles.TryGetValue(worldPoint, out _tile))
            {
                _tile.TilemapMember.SetTileFlags(_tile.LocalPlace, TileFlags.None);

                _tile.TilemapMember.SetTileFlags(_tile.LocalPlace, TileFlags.None);
                _tile.TilemapMember.SetColor(_tile.LocalPlace, Color.green);
            }

        }
    }
}
