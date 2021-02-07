using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosedionScript : MonoBehaviour
{
    public float moveSpeed;

    public float moveRate;
    private float currentTimer = 0f;

    private int xPos = 3;
    private int yPos = 7;

    private iPAttack attackBehaviour;

    private iPMovement movementBehaviour = new StrafeBehaviour();

    private void Awake()
    {
        //movementBehaviour = new StrafeBehaviour();
        //movementBehaviour.Move(gameObject.transform, moveSpeed);
    }

    private void Start()
    {
        StartCoroutine(stateMachine());
    }

    void Update()
    {
        currentTimer += Time.deltaTime * moveRate;

        if (currentTimer > 10.0f)
        {
            Debug.Log("The Big P is moving");
            currentTimer = 0f;
            movementBehaviour.Move(gameObject.transform, moveSpeed * 100);
        }
    }

    IEnumerator stateMachine()
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
}
