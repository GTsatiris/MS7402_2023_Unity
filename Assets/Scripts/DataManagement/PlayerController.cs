using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("k"))
        {
            Debug.Log("Saving...");
            GameManager.SaveGameData();
        }
        if(Input.GetKeyDown("l"))
        {
            Debug.Log("Loading...");
            GameManager.LoadGameData();
        }

        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(horizontal, 0.0f, vertical);

        GameManager.GAME_DATA.position = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Good"))
        {
            GameManager.GAME_DATA.score += 10;
            Debug.Log("SCORE: " + GameManager.GAME_DATA.score);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bad"))
        {
            GameManager.GAME_DATA.health -= 10;
            Debug.Log("HEALTH: " + GameManager.GAME_DATA.health);
            Destroy(collision.gameObject);
        }
    }
}
