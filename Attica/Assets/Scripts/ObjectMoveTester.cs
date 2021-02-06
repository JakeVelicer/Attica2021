using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveTester : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = PathMovement.GetMovement(gameObject.transform, Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = PathMovement.GetMovement(gameObject.transform, Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = PathMovement.GetMovement(gameObject.transform, Direction.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = PathMovement.GetMovement(gameObject.transform, Direction.Right);
        }
    }
}
