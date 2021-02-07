using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour, iUnit
{

    public enum UnitType: int
    {
        Offensive,
        Defensive
    }

    public UnitType unitType;

    public bool hasAttack = false;
    public float buildSpeed;
    public int cost;
    public float health;

    public virtual void Action()
    {
        // code to execute when unit is built
    }

    public virtual void build()
    {
        // code to build tower
    }

    public UnitType GetUnitType()
    {
        return unitType;
    }


    public bool canAttack()
    {
        return hasAttack;
    }

    public float GetBuildSpeed()
    {
        return buildSpeed;
    }

    public int GetCost()
    {
        return cost;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetBuildSpeed(float newBuildSpeed)
    {
        buildSpeed = newBuildSpeed;
    }

    public void SetCost(int newCost)
    {
        cost = newCost;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    public void takeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            DestroySelf();
        }

    }

    public void DestroySelf()
    {
        gameObject.SetActive(false);
    }
}
