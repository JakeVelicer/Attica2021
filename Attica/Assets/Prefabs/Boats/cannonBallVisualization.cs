using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallVisualization : MonoBehaviour
{
    private Transform target;

    public float smoothSpeed = 0.05f;

    private void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
