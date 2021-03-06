﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType: int
    {
        Sand,
        Water
    }

    public int column;
    public int distance;
    public Transform OceanStart;

    [SerializeField] private TileType tileType;
    private bool isOccupied;

    public TileType GetTileType()
    {
        return tileType;
    }

    public void SetOccupied(bool givenOccupy)
    {
        isOccupied = givenOccupy;
    }

    public bool GetOccupied()
    {
        return isOccupied;
    }
}
