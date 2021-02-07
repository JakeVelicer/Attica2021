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
    public static Vector3 GetMovementOverDistance(Transform entity, Direction givenDirection, int travel)
    {
        Transform destination = entity;
        for (int i = 0; i < travel; i++)
        {
            destination.position = GetMovement(destination, givenDirection);
        }
        return destination.position;
    }

    public static Vector3 GetMovement(Transform entity, Direction givenDirection)
    {
        Vector3 destination = new Vector3(0, 0.25f, 0);
        Vector3 entityPos = entity.position;
        switch(givenDirection)
        {
            case Direction.Up:
                destination = entityPos += new Vector3(0.5f, 0.25f, 0);
                break;

            case Direction.Down:
                destination = entityPos += new Vector3(-0.5f, -0.25f, 0);
                break;

            case Direction.Right:
                destination = entityPos += new Vector3(0.5f, -0.25f, 0);
                break;

            case Direction.Left:
                destination = entityPos += new Vector3(-0.5f, 0.25f, 0);
                break;
        }
        return destination;
    }

    public static IEnumerator Move(Transform entity, Direction givenDirection, int givenTravel, float givenSpeed)
    {
        Vector3 startPosition = entity.position;
        Vector3 endPosition = PathMovement.GetMovementOverDistance(entity, givenDirection, givenTravel);
        float waitTime = givenSpeed / 0.5f;
        
        float elapsedTime = 0;

        PosedionScript posideon = entity.gameObject.GetComponent<PosedionScript>();

        if (posideon != null)
        {
            posideon.SetMidMove(true);
        }
        
        while (elapsedTime < waitTime)
        {
            entity.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (posideon != null)
        {
            posideon.SetMidMove(false);
        }
        



        // Make sure we got there
        entity.position = endPosition;
    }

}
