using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSpawner : MonoBehaviour
{
    public void SpawnAndPositionObject(GameObject objectToSpawn, Tile selectedTile, bool offensive)
    {
        if (offensive == true)
        {
            OffenseUnit objectUnitScript = objectToSpawn.GetComponent<OffenseUnit>();
            GameObject newObject = ObjectPooler.Instance.SpawnFromPool("Wave", selectedTile.transform.position, Quaternion.identity);
            objectToSpawn.GetComponent<MonoBehaviour>().StartCoroutine(PathMovement.Move(objectToSpawn.transform, Direction.Up, selectedTile.distance, objectUnitScript.moveSpeed));            
        }
        else
        {
            BaseUnit objectUnitScript = objectToSpawn.GetComponent<BaseUnit>();
            //selectedTile.transform.position;
        }

    }
}
