using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTestScript : MonoBehaviour, iPoolerObject
{
    public void OnSpawnedByPool()
    {
        StopAllCoroutines();
        StartCoroutine(PathMovement.Move(gameObject.transform, Direction.Down, 9, 2.0f));
    }
}
