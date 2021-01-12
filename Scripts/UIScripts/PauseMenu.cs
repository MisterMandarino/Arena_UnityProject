using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
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
}
