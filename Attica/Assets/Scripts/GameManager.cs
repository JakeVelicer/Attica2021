using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject loseScreen;
    public TextMeshProUGUI currencyText;

    public int wave = 1;
    public int currency;
    public int health;
    public int surviveRoundReward;
    public int stopWaveReward;
    public int hurtPoseidonReward;

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

    private void Update()
    {
        currencyText.text = currency + " Drachma";
    }

    public void NextWave()
    {
        wave++;
        currency += surviveRoundReward;
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
