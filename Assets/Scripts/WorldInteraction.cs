using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    bool isInteracting = false;
    bool isInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (isInTrigger)
                isInteracting = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Vector3 myForward = transform.forward;
            Vector3 interactableForward = other.transform.forward;

            float cosine = Vector3.Dot(myForward, interactableForward);

            if (cosine > 0.5)
            {
                isInTrigger = true;

                if (isInteracting)
                {
                    isInteracting = false;
                    Debug.Log("IS INTERACTING!!");
                }
            }
            else
            { 
                isInTrigger = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            isInTrigger = false;
        }
    }
}
