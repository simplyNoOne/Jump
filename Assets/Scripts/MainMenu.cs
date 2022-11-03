using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Text highScore;
    [SerializeField]
    private Text lastScore;

    private Save save;


    public void Awake()
    {
        Cursor.visible = true;
        RefreshScores();
    }


    public void RefreshScores()
    {
        save = GetComponentInParent<Save>();
        save.LoadFile();
        highScore.text = save.GetBestScore().ToString();
        lastScore.text = save.GetLastScore().ToString("D3");
    }

    public void PlayGame()
    {
        Cursor.visible = false;
        save.SaveFile();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
