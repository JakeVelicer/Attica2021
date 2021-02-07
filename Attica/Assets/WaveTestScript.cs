using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTestScript : MonoBehaviour, iPoolerObject, iEnemy
{
    public float health;

    public void Attack()
    {
        
    }

    public void GetDestroyed()
    {
        gameObject.SetActive(false);
    }

    public float GetHealth()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void OnSpawnedByPool()
    {
        StopAllCoroutines();
        StartCoroutine(PathMovement.Move(gameObject.transform, Direction.Down, 9, 2.0f));
    }

    public void SetHealth(float newHealth)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        Debug.Log("Wave Took Damage!");
    }
}
