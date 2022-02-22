using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        playBackgroundMusic();
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
