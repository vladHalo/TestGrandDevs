using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioClip[] musicClip;
    public Slider volumeSlider;

    AudioSource soundSource;
    AudioSource musicSource;
    
    void Start()
    {
        soundSource = transform.GetChild(0).GetComponent<AudioSource>();
        musicSource = transform.GetChild(1).GetComponent<AudioSource>();
    }

    public void ChangeMusic(int i)
    {
        musicSource.clip = musicClip[i];
        musicSource.Play();
    }

    public void ChangeVolume()
    {
        soundSource.volume = volumeSlider.value;
        musicSource.volume = volumeSlider.value;
    }

    public void PlaySound() => soundSource.Play();
}
