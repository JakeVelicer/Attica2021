using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTest : MonoBehaviour
{
    public Transform targetTransform;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(occasionalShot());
    }

    public IEnumerator occasionalShot()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            Shoot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = targetTransform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
    }

    public void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right);

        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
        }
    }
}
