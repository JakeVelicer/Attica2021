using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceBehaviour : iPMovement
{
    public void Move(Transform targetToMove, float speed)
    {
        //randomly choose left or right

        Debug.Log("move script is being called");

        float randomNum = Random.Range(0f, 1f);

        Direction directionToMove = Direction.Down;

        //choose how far he's going to advance

        int distance = Random.Range(1, 3);

        int currentY = targetToMove.GetComponent<PosedionScript>().GetYPos();

        while (currentY - distance < 1)
        {
            if (currentY == 1)
            {
                directionToMove = Direction.Up;
                break;
            }

            distance = Random.Range(1, 3);
        }

 
        targetToMove.GetComponent<PosedionScript>().SetYPos(currentY - distance);
  

        targetToMove.GetComponent<MonoBehaviour>().StartCoroutine(PathMovement.Move(targetToMove, directionToMove, distance, 0.25f));

    }
}
