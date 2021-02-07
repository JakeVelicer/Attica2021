using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OffenseUnit : BaseUnit
{
    public float damage;
    public float attackSpeed;
    private float currentTimer = 0;
    public float moveSpeed;

    public float range;

    public override void Action()
    {
        //Attack();
    }
    public void Attack()
    {
        //check if posideon or an enemy are in range
        currentTimer += Time.deltaTime * attackSpeed;


        var hitColliders = Physics2D.OverlapCircleAll(transform.position, range, 1 << LayerMask.NameToLayer("Enemy"));

        if (currentTimer >= 1.0f)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                PosedionScript posedion = hitColliders[i].GetComponent<PosedionScript>();
                iEnemy enemy = hitColliders[i].GetComponent<iEnemy>();

                if (posedion != null)
                {
                    posedion.TakeDamage(damage);
                }
                else if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }

            currentTimer = 0f;
        }


    }

    void Update()
    {
        Attack();
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
