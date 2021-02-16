using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveUnit : BaseUnit
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] stages;
    private float maxHealth;

    private void Start()
    {
        maxHealth = GetHealth();
    }

    public override void takeDamage(float damageToTake)
    {
        base.takeDamage(damageToTake);
        SetSprite();
    }

    public void SetSprite()
    {
        float healthPercent;
        int choice;

        healthPercent = (GetHealth() / maxHealth) * 100;

        //Debug.Log((healthPercent / stages.Length) / 10);
        choice = Mathf.FloorToInt((healthPercent / stages.Length) / 10);
        choice--; // For having a higher chance at showing the lowest degredation
        choice = Mathf.Clamp(choice, 0, stages.Length - 1);
        
        spriteRenderer.sprite = stages[choice];
    }
}
