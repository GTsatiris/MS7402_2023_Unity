using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnState : State
{
    public override void ExecuteState()
    {
        attributes.transform.position = Vector3.MoveTowards(attributes.transform.position, attributes.startingPoint, attributes.returnSpeed * Time.deltaTime);
        attributes.transform.LookAt(attributes.startingPoint);
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

        float distanceFromOrigin = Vector3.Distance(attributes.transform.position, attributes.startingPoint);
        if (distanceFromOrigin < 0.05f)
        {
            return SentryControllerFSM._IDLE;
        }

        return SentryControllerFSM._RETURN;
    }
}
