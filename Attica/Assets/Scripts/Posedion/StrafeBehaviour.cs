using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StrafeBehaviour : iPMovement
{
    public void Move(Transform targetToMove, float speed)
    {
        //randomly choose left or right

        Debug.Log("move script is being called");

        float randomNum = Random.Range(0f, 1f);

        Direction directionToMove = Direction.Right;

        if (randomNum <= 0.5f)
        {
            directionToMove = Direction.Left;
        }

        //choose how far he's going to strafe

        int distance = Random.Range(1, 4);

        int currentX = targetToMove.GetComponent<PosedionScript>().GetXPos();

        while (directionToMove == Direction.Left && currentX - distance < 1)
        {
            if (currentX == 1)
            {
                directionToMove = Direction.Right;
                break;
            }

             distance = Random.Range(1, 4);
        }

        while (directionToMove == Direction.Right && currentX + distance > 5)
        {
            if (currentX == 5)
            {
                directionToMove = Direction.Left;
                break;
            }

            distance = Random.Range(1, 4);
        }

        if (directionToMove == Direction.Left)
        {
            targetToMove.gameObject.GetComponent<PosedionScript>().SetXPos(currentX - distance);
        }
        else
        {
            targetToMove.gameObject.GetComponent<PosedionScript>().SetXPos(currentX + distance);
        }

        Debug.Log("X: " + targetToMove.gameObject.GetComponent<PosedionScript>().GetXPos());

        


        targetToMove.GetComponent<MonoBehaviour>().StartCoroutine(PathMovement.Move(targetToMove, directionToMove, distance, 0.25f));

    }


}
