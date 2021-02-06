using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction: int
{
    Up,
    Down,
    Left,
    Right
}

public static class PathMovement
{
    public static Vector3 GetMovement(Transform entity, Direction givenDirection)
    {
        Vector3 destination = new Vector3(0, 0.25f, 0);

        switch(givenDirection)
        {
            case Direction.Up:
                destination = entity.position += new Vector3(0.5f, 0.25f, 0);
                break;

            case Direction.Down:
                destination = entity.position += new Vector3(-0.5f, -0.25f, 0);
                break;

            case Direction.Right:
                destination = entity.position += new Vector3(0.5f, -0.25f, 0);
                break;

            case Direction.Left:
                destination = entity.position += new Vector3(-0.5f, 0.25f, 0);
                break;
        }
        return destination;
    }
}
