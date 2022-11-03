using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject button;

    private bool paused;

    private void Start()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        paused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
            Resume();
    }

    public void Pause()
    {
#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        Cursor.visible = true;
#endif
        pauseMenu.SetActive(true);
        paused = true;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
        Cursor.visible = false;
#else
        button.SetActive(true);
#endif
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1.0f;
    }

    public void PausePressed()
    {
        if (paused)
        {
#if !(UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN)
            button.SetActive(true);
#endif
            Resume();
        }
        else
        {
#if !(UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN)
            button.SetActive(false);
#endif
            Pause();
        }
    }

    public void Home()
    {
        Player.GetComponent<ScoreCounter>().SaveResults();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
