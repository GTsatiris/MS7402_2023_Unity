using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryControllerFSM : MonoBehaviour
{
    [SerializeField]
    StateParameters attributes;

    public static IdleState _IDLE;
    public static ChaseState _CHASE;
    public static ReturnState _RETURN;

    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        _IDLE = new IdleState();
        _CHASE = new ChaseState();
        _RETURN = new ReturnState();

        currentState = _IDLE;
        attributes.transform = transform;
        attributes.startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.attributes = attributes;
        currentState.ExecuteState();
        currentState = currentState.CheckForTransition();
    }
}
