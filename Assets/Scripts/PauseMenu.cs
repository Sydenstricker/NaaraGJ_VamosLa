using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = true;
    public GameObject pauseMenuUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        Cursor.visible = false;       
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        Cursor.visible = true;        
    }
}
