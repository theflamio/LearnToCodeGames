using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public PlayerController playerController;

    public GameObject pauseMenuUI;

    public GameObject winMenuUI;

    public GameObject loseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else
        {
            if (playerController.playerWonGame)
            {
                PlayerWonGame();
            }
            else if (playerController.playerLostGame)
            {
                PlayerLostGame();
            }
        }        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        GameIsPause = false;
    }

    public void OptionGame()
    {

    }

    public void TryAgain()
    {
        loseMenuUI.SetActive(false);
        Scene currentScene = SceneManager.GetActiveScene(); SceneManager.LoadScene(currentScene.name);
    }

    public void NextLevel()
    {
        winMenuUI.SetActive(false);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayerWonGame()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayerLostGame()
    {
        loseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
