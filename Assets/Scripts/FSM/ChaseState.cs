using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public override void ExecuteState()
    {
        attributes.transform.position = Vector3.MoveTowards(attributes.transform.position, attributes.target.position, attributes.chaseSpeed * Time.deltaTime);
        attributes.transform.LookAt(attributes.target);
    }

    public override State CheckForTransition()
    {
        float distanceFromTarget = Vector3.Distance(attributes.transform.position, attributes.target.position);

        Vector3 sentryToTarget = Vector3.Normalize(attributes.target.position - attributes.transform.position);
        float cosine = Vector3.Dot(attributes.transform.forward, sentryToTarget);

        if ((distanceFromTarget > attributes.disengagementDist) || (cosine <= 0.26f))
        {
            return SentryControllerFSM._RETURN;
        }
        else
        {
            return SentryControllerFSM._CHASE;
        }
    }
}
