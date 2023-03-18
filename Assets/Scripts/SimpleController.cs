using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    [SerializeField]
    float speed = 1.0f;

    [SerializeField]
    float rotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKey(KeyCode.W))
        {
            //transform.position += new Vector3(0.0f, 0.0f, speed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position -= new Vector3(0.0f, 0.0f, speed * Time.deltaTime);
            transform.position -= transform.forward * speed * Time.deltaTime;
        }*/

        /*if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
            transform.position -= transform.right * speed * Time.deltaTime;
        }*/

        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0.0f, 0.0f, translation);

        transform.Rotate(0.0f, rotation, 0.0f);
    }
}
