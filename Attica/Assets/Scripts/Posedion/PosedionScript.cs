using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosedionScript : MonoBehaviour
{
    public float moveSpeed;
    public float attackRate;
    public float healthRemaining = 10f;

    public float moveRate;
    private float moveTimer = 0f;
    private float attackTimer = 0f;

    private int xPos = 3;
    private int yPos = 7;
    private bool midMove = false;

    private iPAttack attackBehaviour;

    private iPMovement movementBehaviour = new StrafeBehaviour();

    private void Awake()
    {
        //movementBehaviour = new StrafeBehaviour();
        //movementBehaviour.Move(gameObject.transform, moveSpeed);

        attackBehaviour = new CreateWaveBehaviour();
    }

    private void Start()
    {
        StartCoroutine(movementStateMachine());
    }

    void Update()
    {
        moveTimer += Time.deltaTime * moveRate;
        attackTimer += Time.deltaTime * attackRate;

        if (moveTimer > 10.0f)
        {

            moveTimer = 0f;
            movementBehaviour.Move(gameObject.transform, moveSpeed * 100);
        }

        if (attackTimer > 10f && !midMove)
        {
            attackBehaviour.Attack(gameObject.transform);
            attackTimer = 0f;
        }
    }

    IEnumerator movementStateMachine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            NewMoveBehaviour();
        }

    }

    void NewMoveBehaviour()
    {
        float randomNum = Random.Range(0f, 1f);

        if (randomNum > 0.90f)
        {
            movementBehaviour = new AdvanceBehaviour();
        }
        else
        {
            movementBehaviour = new StrafeBehaviour();
        }
    }

    public int GetXPos()
    {
        return xPos;
    }

    public void SetXPos(int newPos)
    {
        xPos = newPos;
    }

    public int GetYPos()
    {
        return yPos;
    }

    public void SetYPos(int newPos)
    {
        yPos = newPos;
    }

    public void SetMidMove(bool newMidMove)
    {
        midMove = newMidMove;
    }

    public void TakeDamage(float damageToTake)
    {
        healthRemaining -= damageToTake;

        Debug.Log("Posideon Took Damage!");
    }
}
