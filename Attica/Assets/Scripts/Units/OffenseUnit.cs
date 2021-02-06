using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffenseUnit : BaseUnit
{
    public float attackSpeed;
    public float moveSpeed;

    public override void Action()
    {
        Attack();
    }
    public void Attack()
    {
        // this is the code to move the ship
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public void SetAttackSpeed(float newAttackSpeed)
    {
        attackSpeed = newAttackSpeed;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }
}
