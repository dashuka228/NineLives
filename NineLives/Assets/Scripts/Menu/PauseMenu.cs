using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private GameObject help;

    private string tecMenu = "PauseMenu";

    private void Update()
    {
        if (tecMenu == "PauseMenu")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
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
        }

        else if (tecMenu == "Help")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                help.SetActive(false);
                pauseMenuUI.SetActive(true);
                tecMenu = "PauseMenu";
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Help ()
    {
        pauseMenuUI.SetActive(false);
        help.SetActive(true);
        tecMenu = "Help";
    }

    public void ExitGame ()
    {
        Debug.Log("оньек мюуси");
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Menu");
        //Application.Quit();
    }
}
