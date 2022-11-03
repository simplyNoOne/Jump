using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save : MonoBehaviour
{

    int lastScore;
    int bestScore;
    public bool SFXmuted;
    public bool MUSICmuted;


    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(lastScore, bestScore, MUSICmuted, SFXmuted);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();

        lastScore = data.currentScore;
        bestScore = data.bestScore;
        MUSICmuted = data.MusicMuted;
        SFXmuted = data.SfxMuted;

    }

    public void ClearData()
    {
        lastScore = 0;
        bestScore = 0;
        MUSICmuted = false;
        SFXmuted = false;
        SaveFile();
    }

    public int GetBestScore() { return bestScore; }
    public void SetBestScore(int score) { bestScore = score; }

    public int GetLastScore() { return lastScore; }
    public void SetLastScore(int score) { lastScore = score; }

    public void MuteM() { MUSICmuted = true; }
    public void MuteS() { SFXmuted = true; }

    public void UnmuteM() { MUSICmuted = false; }
    public void UnmuteS() { SFXmuted = false; }

}
