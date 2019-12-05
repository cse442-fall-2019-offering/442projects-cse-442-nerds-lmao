using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver;
    public static bool gameIsWon;

    public GameObject gameOverUI;
    public GameObject gameWonUI;

    void Start()
    {
        gameIsOver = false;
        gameIsWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
            return;
        if (gameIsWon)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (PlayerStats.Rounds > 10)
        {
            GameWon();
        }
    }

    public void Toggle(GameObject UI)
    {
        UI.SetActive(!UI.activeSelf);

        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        Toggle(gameOverUI);
    }

    void GameWon()
    {
        gameIsWon = true;
        Toggle(gameWonUI);
    }

    public void Retry()
    {
        if (gameIsWon)
        {
            Toggle(gameWonUI);
        }
        else {
            Toggle(gameOverUI);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        if (gameIsWon)
        {
            Toggle(gameWonUI);
        }
        else
        {
            Toggle(gameOverUI);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - PlayerStats.levelNumber);
    }

}