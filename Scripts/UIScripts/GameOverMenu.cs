using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public Text scoreText;
    public Text bestScoreText;
    void Start()
    {
        PrintScoreText();
        PrintBestScoreText();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private void PrintScoreText()
    {
        scoreText.text = GameManager.score.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Arena");
    }

    private void PrintBestScoreText()
    {
        if(GameManager.score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore",GameManager.score);
        }
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
}
