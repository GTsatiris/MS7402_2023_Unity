using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform objectToFollow;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //maintain the same offset as original setup
        offset = transform.position - objectToFollow.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = objectToFollow.position + offset;
    }
}
