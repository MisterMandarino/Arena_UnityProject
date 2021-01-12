using UnityEngine;
using UnityEngine.UI;
public class OptionMenu : MonoBehaviour
{
    private AudioManager audioManager;
    public Slider slider;

    void Awake()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("BestScore");
    }

    public void SetVolume()
    {
        audioManager.SetVolume(slider.value);
    }

    public void LessVolume()
    {
        slider.value -= 0.2f;
        SetVolume();
    }

    public void PlusVolume()
    {
        slider.value += 0.2f;
        SetVolume();
    }
}
