using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameData GAME_DATA;

    private void Awake()
    {
        if (GAME_DATA == null)
        {
            GAME_DATA = new GameData();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SaveGameData()
    {
        GameObject player = GameObject.Find("Player");
        GAME_DATA.position = player.transform.position;

        GameObject[] goodCollectibles = GameObject.FindGameObjectsWithTag("Good");
        GameObject[] badCollectibles = GameObject.FindGameObjectsWithTag("Bad");

        foreach(GameObject good in goodCollectibles)
        {
            GAME_DATA.goodCollectiblePositions.Add(good.transform.position);
        }

        foreach (GameObject bad in badCollectibles)
        {
            GAME_DATA.badCollectiblePositions.Add(bad.transform.position);
        }

        string jsonData = JsonUtility.ToJson(GAME_DATA);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", jsonData);
    }

    public static void LoadGameData()
    {

    }
}
