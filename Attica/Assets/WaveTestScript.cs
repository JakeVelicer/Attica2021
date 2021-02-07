using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTestScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(PathMovement.Move(gameObject.transform, Direction.Down, 9, 2.0f));
    }
}
