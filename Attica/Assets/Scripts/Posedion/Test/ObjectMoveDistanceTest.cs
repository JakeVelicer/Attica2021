using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveDistanceTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PathMovement.Move(transform, Direction.Up, 5, 1.5f));
    }

}
