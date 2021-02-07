using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTestScript : MonoBehaviour, iPoolerObject, iEnemy
{
    public float health;
    public float damage;

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

        if (health <= 0)
        {
            GetDestroyed();
        }

        Debug.Log("Wave Took Damage!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            iUnit unit = collision.gameObject.GetComponent<iUnit>();

            unit.takeDamage(damage);
            Debug.Log("Boat Took Damage");

            GetDestroyed();



        }

    }
}
