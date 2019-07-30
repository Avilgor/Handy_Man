using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool paused;

    [SerializeField]
    public GameObject pauseMenu;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                paused = true;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
        }
    }


    public void ResumeGame()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}