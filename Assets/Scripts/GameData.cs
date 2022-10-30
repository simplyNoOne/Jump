using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currentScore;
    public int bestScore;

    public GameData(int cS, int bS)
    {
        currentScore = cS;
        bestScore = bS;
    }
}
