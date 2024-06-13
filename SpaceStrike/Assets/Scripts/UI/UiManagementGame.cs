using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManagementGame : MonoBehaviour
{
    public static UiManagementGame instance;
    public GameObject pausedUI;

    public GameObject gameOverUI;

    private bool isPaused = true ;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Paused();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Resumed();
        }

        
    }

    public void Paused(){
        Time.timeScale = 0f;
        pausedUI.SetActive(true);
        isPaused = false;
        

    }

    public void Resumed(){
        Time.timeScale = 1f;
        pausedUI.SetActive(false);
        isPaused = true;

    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);

    }

    public void ResetOver()
    {
    }
}
