using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text bestScore;

    void Start()
    {
        UpdateScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Arena");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateScore()
    {
        bestScore.text = PlayerPrefs.GetInt("BestScore",0).ToString();
    }
}
