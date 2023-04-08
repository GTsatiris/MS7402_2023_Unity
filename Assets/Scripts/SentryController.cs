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
    Vector3 startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        isIdle = true;
        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, target.position);

        Vector3 sentryToTarget = Vector3.Normalize(target.position - transform.position);
        float cosine = Vector3.Dot(transform.forward, sentryToTarget);

        if ((distanceFromTarget <= detectionDist) && (cosine > 0.26f)) // CHASING STATE
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target);
            isIdle = false;
        }
        else // IDLE or RETURN STATES
        {
            if (isIdle) //IDLE STATE
            {
                transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
            }
            else //RETURN STATE
            {
                transform.position = Vector3.MoveTowards(transform.position, startingPoint, speed * Time.deltaTime);
                transform.LookAt(startingPoint);

                float distanceFromOrigin = Vector3.Distance(transform.position, startingPoint);
                if(distanceFromOrigin < 0.05f)
                {
                    isIdle = true;
                }
            }
        }
    }
}
