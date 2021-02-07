using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTestScript : MonoBehaviour, iPoolerObject, iEnemy
{
    public float health;
    public float damage;
    public float waveSpeed = 1;

    public void Attack()
    {
        
    }

    public void GetDestroyed()
    {
        GameManager.instance.currency += GameManager.instance.stopWaveReward;
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
        float randomSpeedOffset = Random.Range(-0.5f, 0.5f);
        StartCoroutine(PathMovement.Move(gameObject.transform, Direction.Down, 9,  waveSpeed + randomSpeedOffset));
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
        else if (collision.gameObject.tag == "City")
        {
            GameManager.instance.DamageCity(1);
            //collision.gameObject.SetActive(false);
            GetDestroyed();
        }
    }
}
