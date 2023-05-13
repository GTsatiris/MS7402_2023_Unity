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
}