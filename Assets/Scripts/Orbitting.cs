using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitting : MonoBehaviour
{
    [SerializeField]
    float speed = 1.2f;

    [SerializeField]
    Transform orbitCenter;

    [SerializeField]
    float orbitRadius = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = Mathf.Cos(Time.time * speed) * orbitRadius;
        float newZ = Mathf.Sin(Time.time * speed) * orbitRadius;

        Vector3 newPosition = new Vector3(newX, 0.0f, newZ);

        transform.position = newPosition + orbitCenter.position;
    }
}
