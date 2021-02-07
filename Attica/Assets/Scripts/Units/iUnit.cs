using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iUnit 
{
    float GetHealth();

    void SetHealth(int newHealth);

    void takeDamage(float damageToTake);

    void DestroySelf();

    bool canAttack();

    void Action();

    int GetCost();

    void SetCost(int newCost);

    float GetBuildSpeed();

    void SetBuildSpeed(float newBuildSpeed);

    void build();
}
