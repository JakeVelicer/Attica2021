using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWaveBehaviour : iPAttack
{
    public void Attack(Transform attacker)
    {
        //left or right

        float randomNum = Random.Range(0f, 1f);

        Direction randomDirection = Direction.Left;

        if (randomNum > 0.5f)
        {
            randomDirection = Direction.Right;
        }
        else if (randomNum < 0.35)
        {
            randomDirection = Direction.Down;
        }

        //make sure we're spawning it in bounds;

        int currentXPosition = attacker.GetComponent<PosedionScript>().GetXPos();

        if (currentXPosition == 1 && randomDirection == Direction.Left)
        {
            randomDirection = Direction.Right;
        }
        else if (currentXPosition == 5 && randomDirection == Direction.Right)
        {
            randomDirection = Direction.Left;
        }

        Vector3 waveSpawnPosition = PathMovement.GetMovement(attacker, randomDirection);

        //spawn object from pool

        ObjectPooler.Instance.SpawnFromPool("Wave", waveSpawnPosition, Quaternion.identity);
    }
}
