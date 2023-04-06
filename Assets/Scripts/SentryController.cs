using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    float detectionDist;

    [SerializeField]
    Transform target;

    bool isIdle;

    // Start is called before the first frame update
    void Start()
    {
        isIdle = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, target.position);

        Vector3 sentryToTarget = Vector3.Normalize(target.position - transform.position);
        float cosine = Vector3.Dot(transform.forward, sentryToTarget);

        if ((distanceFromTarget <= detectionDist) && (cosine > 0.5f)) // CHASING STATE
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else // IDLE or RETURN STATES
        {
            if (isIdle) //IDLE STATE
            {
                transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
            }
            else //RETURN STATE
            {

            }
        }
    }
}
