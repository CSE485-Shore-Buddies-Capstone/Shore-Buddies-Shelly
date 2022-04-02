using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        playBackgroundMusic();
        volumeSlider.onValueChanged.AddListener(setBackgroundVolume);
    }

    public void setBackgroundVolume(float volume) {
        this.backgroundMusic.volume = volume;
    }

    public void pauseBackgroundMusic() {
        this.backgroundMusic.Pause();
    }

    public void playBackgroundMusic() {
        this.backgroundMusic.Play();
    }
}
