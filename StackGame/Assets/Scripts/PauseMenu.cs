using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector][SerializeField] static bool GameIsPaused = false;
    [HideInInspector][SerializeField] public static bool GameIsFinished = false;
    [SerializeField] GameObject _pauseMenuUI;
    [SerializeField] GameObject _bestScoreUI;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] private CubeMove cubePrefab;
    [SerializeField] AudioSource _back;
    static int bestScore = 0;
    int currentScore;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (GameIsFinished) 
        { 
            Pause();
            _back.Stop();
            currentScore = GameObject.FindGameObjectsWithTag("Cube").Length - 1;
           if (bestScore <= currentScore)
            {
               bestScore = currentScore;
            }

            _text.text = "Best: " + bestScore;
            _bestScoreUI.SetActive(true);
            cubePrefab.speed = 6f;
        }

    }
    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        GameIsFinished = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
