using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iUnit 
{
    int GetHealth();

    void SetHealth(int newHealth);

    bool canAttack();

    void Action();

    int GetCost();

    void SetCost(int newCost);

    float GetBuildSpeed();

    void SetBuildSpeed(float newBuildSpeed);

    void build();
}
