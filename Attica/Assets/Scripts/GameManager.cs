using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject loseScreen;

    public int wave = 1;
    public int currency;
    public int health;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {

    }

    public void NextWave()
    {
        wave++;

        Debug.Log("Wave: " + wave.ToString());
    }

    public void LoseGame()
    {
        loseScreen.SetActive(true);
    }

    public void DamageCity(int cityDamage)
    {
        health -= cityDamage;

        if (health <= 0)
        {
            LoseGame();
        }
    }
}
