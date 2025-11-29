using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;

    public float slowPitch = 0.8f;   
    public float normalPitch = 1.0f;  
    public float fastPitch = 1.3f; 

    private int speedIndex = 1; 

    void Start()
    {
        if (musicSource != null)
        {
            musicSource.loop = true;
            musicSource.playOnAwake = false;

            musicSource.pitch = normalPitch;
            speedIndex = 1;
        }
    }

    public void TogglePlay()
    {
        if (musicSource == null) return;

        if (musicSource.isPlaying)
        {
            musicSource.Pause(); 
        }
        else
        {
            musicSource.Play();
        }
    }

    public void SwitchSpeed()
    {
        if (musicSource == null) return;

        speedIndex = (speedIndex + 1) % 3;

        switch (speedIndex)
        {
            case 0:
                musicSource.pitch = slowPitch;
                break;
            case 1:
                musicSource.pitch = normalPitch;
                break;
            case 2:
                musicSource.pitch = fastPitch;
                break;
        }
    }
}
