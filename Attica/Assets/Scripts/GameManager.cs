using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject loseScreen;
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI waveText;
    public RectTransform poseidonHealthBar;
    public Image[] cityHealthUI;

    public int wave = 1;
    public int currency;
    public int health;
    public int surviveRoundReward;
    public int stopWaveReward;
    public int hurtPoseidonReward;

    private PosedionScript posedion;

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
        posedion = GameObject.FindObjectOfType<PosedionScript>();
        waveText.text = "Wave: " + wave;
    }

    private void Update()
    {
        currencyText.text = currency + " Drachma";
        poseidonHealthBar.sizeDelta = new Vector2 ((5 * posedion.healthRemaining) - 500, 0);
    }

    public void NextWave()
    {
        wave++;
        currency += surviveRoundReward;
        waveText.text = "Wave: " + wave;
        //Debug.Log("Wave: " + wave.ToString());
    }

    public void LoseGame()
    {
        loseScreen.SetActive(true);
    }

    public void DamageCity(int cityDamage)
    {
        health -= cityDamage;

        for (int i = cityHealthUI.Length; i > 0; i--)
        {
            if (cityHealthUI[i].enabled)
            {
                cityHealthUI[i].enabled = false;
                break;
            }
        }

        if (health <= 0)
        {
            LoseGame();
        }
    }
}
