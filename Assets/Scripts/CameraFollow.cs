using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    float cameraSpeed = 10.0f;
    [SerializeField]
    float rotationSpeed = 10.0f;

    [SerializeField]
    Transform IdealCameraPosition;

    [SerializeField]
    Transform IdealCameraTarget;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = IdealCameraPosition.position;
        transform.LookAt(IdealCameraTarget);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, IdealCameraPosition.position, cameraSpeed * Time.deltaTime);

        //transform.LookAt(IdealCameraTarget);
        Vector3 targetDirection = Vector3.Normalize(IdealCameraTarget.position - transform.position);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
