using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pausePanel;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        pausePanel.SetActive(isPaused);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        pausePanel.SetActive(isPaused);
    }
}
