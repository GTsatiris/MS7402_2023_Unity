using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject goodPrefab;

    [SerializeField]
    GameObject badPrefab;

    [SerializeField]
    Vector2 X_range;

    [SerializeField]
    Vector2 Z_range;

    [SerializeField]
    int totalCollectibles;

    [SerializeField]
    float badToGoodRatio;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < totalCollectibles; i++)
        {
            float dice = Random.Range(0.0f, 1.0f);

            Vector3 randomPosition = new Vector3(Random.Range(X_range.x, X_range.y), 1.0f, Random.Range(Z_range.x, Z_range.y));
            
            if(dice <= badToGoodRatio)
            {
                Instantiate(badPrefab, randomPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(goodPrefab, randomPosition, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
