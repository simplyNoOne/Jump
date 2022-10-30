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
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        paused = true;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1.0f;
    }

    public void Home()
    {
        Player.GetComponent<ScoreCounter>().SaveResults();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
