using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatBehaviour : iPMovement
{
    public void Move(Transform targetToMove, float speed)
    {
        //randomly choose left or right

        Debug.Log("move script is being called");

        float randomNum = Random.Range(0f, 1f);

        Direction directionToMove = Direction.Up;

        //choose how far he's going to retreat

        int distance = Random.Range(1, 3);

        int currentY = targetToMove.GetComponent<PosedionScript>().GetYPos();

        while (currentY + distance > 7)
        {
            if (currentY == 7)
            {
                directionToMove = Direction.Down;
                break;
            }

            distance = Random.Range(1, 3);
        }


        targetToMove.GetComponent<PosedionScript>().SetYPos(currentY + distance);

        targetToMove.GetComponent<MonoBehaviour>().StartCoroutine(PathMovement.Move(targetToMove, directionToMove, distance, 0.25f));

    }
}
