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


    public void Awake()
    {
        Cursor.visible = true;
        Save save = GetComponent<Save>();
        save.LoadFile();
        highScore.text = save.GetBestScore().ToString();
        lastScore.text = save.GetLastScore().ToString("D3");
    }

    public void PlayGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
