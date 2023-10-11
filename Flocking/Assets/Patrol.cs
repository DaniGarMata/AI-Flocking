using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    float freq = 0f;
    public float maxVelocity;
    public float turnSpeed;
    private Vector3 target;
    public GameObject[] wayPoints;
    public int patrolWP = 0;

    void Start()
    {
        target = wayPoints[patrolWP].transform.position;
    }
    void Update()
    {
        freq += Time.deltaTime;
        if (freq > 0.5)
        {
            freq -= 0.5f;
            if (Vector3.Distance(target, transform.position) < 0.1f)
            {
                patrolWP = (patrolWP + 1) % wayPoints.Length;
                target = wayPoints[patrolWP].transform.position;
            }

        }
        Vector3 direction = target - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                                      Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * maxVelocity * Time.deltaTime;
    }
}
