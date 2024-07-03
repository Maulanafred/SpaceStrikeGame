using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UiManagementGame : MonoBehaviour
{
    public UnityEvent pause;
    public UnityEvent resume;

    public static UiManagementGame instance;
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject options;

    private bool isPaused = false;
    private bool isGameOver;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver )
        {
            if (isPaused)
            {

                Resumed();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Paused()
    {
        Time.timeScale = 0f;
        pausedUI.SetActive(true);
        options.SetActive(false);  // Ensure options are hidden when pausing
        isPaused = true;
        pause.Invoke();  // Trigger the pause event
    }

    public void Resumed()
    {
        Time.timeScale = 1f;
        pausedUI.SetActive(false);
        isPaused = false;
        resume.Invoke();  // Trigger the resume event
    }

    public void HideOptions()
    {
        options.SetActive(false);
    }

    public void ShowOptions()
    {
        options.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        isPaused = true;  // Ensure pause state is set correctly
        isGameOver = true;
        gameOverUI.SetActive(true);
    }

    public void Win(){

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        pausedUI.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        // Reload the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }


    public void ResetOver()
    {
        // Reset game over state if needed
    }

    public void StopBGMLevel1(){
        AudioManager.instance.StopBGM(1);

    }
    public void StopBGMLevel2(){
        AudioManager.instance.StopBGM(2);

    }
}
