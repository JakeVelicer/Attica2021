using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSpawner : MonoBehaviour
{
    public void SpawnAndPositionObject(GameObject objectToSpawn, Tile givenTile, bool offensive)
    {
        Tile selectedTile = givenTile;
        GameObject newObject;
        if (offensive == true)
        {
            OffenseUnit objectUnitScript = objectToSpawn.GetComponent<OffenseUnit>();

            newObject = ObjectPooler.Instance.SpawnFromPool(objectToSpawn.name, selectedTile.OceanStart.position, Quaternion.identity);

            newObject.GetComponent<MonoBehaviour>().StartCoroutine(PathMovement.Move
            (newObject.transform, Direction.Up, selectedTile.distance - 1, objectUnitScript.moveSpeed));
        }
        else
        {
            BaseUnit objectUnitScript = objectToSpawn.GetComponent<BaseUnit>();
            newObject = ObjectPooler.Instance.SpawnFromPool(objectToSpawn.name, selectedTile.transform.position, Quaternion.identity);
        }
        selectedTile.SetOccupied(true);
        newObject.GetComponent<BaseUnit>().SetTile(selectedTile);
    }
}
