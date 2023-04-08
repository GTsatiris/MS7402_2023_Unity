using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateParameters
{
    public Transform transform;
    public Transform target;
    public Vector3 startingPoint;

    public float rotationSpeed;
    public float chaseSpeed;
    public float returnSpeed;

    public float detectionDist;
    public float disengagementDist;
}
