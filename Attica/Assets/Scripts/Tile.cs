using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType: int
    {
        Sand,
        Water
    }

    [SerializeField] private TileType tileType;

    public TileType GetTileType()
    {
        return tileType;
    }
}
