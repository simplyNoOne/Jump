using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currentScore;
    public int bestScore;
    public bool MusicMuted;
    public bool SfxMuted;

    public GameData(int cS, int bS, bool mM, bool sM)
    {
        currentScore = cS;
        bestScore = bS;
        MusicMuted = mM;
        SfxMuted = sM;
    }
}
