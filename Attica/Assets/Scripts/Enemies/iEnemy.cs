using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iEnemy
{
    float GetHealth();

    void SetHealth(float newHealth);

    void TakeDamage(float damageToTake);

    void GetDestroyed();

    void Attack();

    void Move();
}
