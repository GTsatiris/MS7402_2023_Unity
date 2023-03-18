using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLerping : MonoBehaviour
{
    [SerializeField]
    float delta = 0.0f;

    [SerializeField]
    Transform starting;

    [SerializeField]
    Transform ending;

    [SerializeField]
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (1 - delta) * starting.position + delta * ending.position;
        delta = Mathf.Cos(Time.time * speed) * 0.5f + 0.5f;
    }
}
