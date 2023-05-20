using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int health;
    public int score;
    public Vector3 position;

    public List<Vector3> goodCollectiblePositions;
    public List<Vector3> badCollectiblePositions;

    public GameData()
    {
        health = 100;
        score = 0;

        goodCollectiblePositions = new List<Vector3>();
        badCollectiblePositions = new List<Vector3>();
    }

    public GameData(int health, int score)
    {
        this.health = health;
        this.score = score;

        goodCollectiblePositions = new List<Vector3>();
        badCollectiblePositions = new List<Vector3>();
    }

}