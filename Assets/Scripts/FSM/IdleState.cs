using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void ExecuteState()
    {
        attributes.transform.Rotate(0.0f, attributes.rotationSpeed * Time.deltaTime, 0.0f);
    }

    public override State CheckForTransition()
    {
        float distanceFromTarget = Vector3.Distance(attributes.transform.position, attributes.target.position);

        Vector3 sentryToTarget = Vector3.Normalize(attributes.target.position - attributes.transform.position);
        float cosine = Vector3.Dot(attributes.transform.forward, sentryToTarget);

        if ((distanceFromTarget <= attributes.detectionDist) && (cosine > 0.26f))
        {
            return SentryControllerFSM._CHASE;
        }
        else
        {
            return SentryControllerFSM._IDLE;
        }
    }
}
