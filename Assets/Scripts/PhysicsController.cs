using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    [SerializeField]
    float force;

    [SerializeField]
    float jumpForce;

    Rigidbody rb;
    Vector3 finalForce;
    Vector3 upwardForce;
    bool jumping = false;
    bool isGrounded = false; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float forwardForce = Input.GetAxis("Vertical") * force;
        float lateralForce = Input.GetAxis("Horizontal") * force;

        finalForce = new Vector3(forwardForce, 0.0f, -lateralForce);

        if (Input.GetKeyDown("space"))
        {
            upwardForce = new Vector3(0.0f, jumpForce, 0.0f);
            jumping = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Force variant
        /*float forwardForce = Input.GetAxis("Vertical") * force;
        float lateralForce = Input.GetAxis("Horizontal") * force;

        Vector3 finalForce = new Vector3(lateralForce, 0.0f, forwardForce);

        rb.AddForce(finalForce);*/
        
        //Torque variant
        
        rb.AddTorque(finalForce);

        if (jumping && isGrounded)
        {
            rb.AddForce(upwardForce, ForceMode.Impulse);
            jumping = false;
            isGrounded = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Sticky"))
        {
            //rb.velocity *= 0.0f;
            rb.angularVelocity *= 0.0f;
        }
    }

}
