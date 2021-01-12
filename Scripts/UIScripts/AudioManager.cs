using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Slider slider;
    public static AudioManager instance;
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("MainTheme");
    }

    public void Play(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
                s.source.Play();
        }
    }

    public void SetVolume(float vol)
    {
        foreach(Sound s in sounds)
        {
            s.source.volume = vol;
        }
    }

}
