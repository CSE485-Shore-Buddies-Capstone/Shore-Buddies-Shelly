using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    private int unmuted; // 0 = muted, 1 = unmuted

    [Header("Volume UI (Drag from hierarchy)")]
    public Slider volumeSlider;
    public GameObject volumeOnButton;
    public GameObject volumeOffButton;
    
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(setBackgroundVolume);
        
        // default values unless there are saved sound settings
        float volume = 0.5f;
        int unmuteState = 1; 

        // load saved volume
        if(PlayerPrefs.HasKey("SavedVolume")){
            volume = PlayerPrefs.GetFloat("SavedVolume");
            setBackgroundVolume(volume);
        }

        // load music status (mute/unmute)
        if(PlayerPrefs.HasKey("SavedMuteUnmute")){
            unmuteState = PlayerPrefs.GetInt("SavedMuteUnmute");
            if(unmuteState == 1){
                playBackgroundMusic();
            }else{
                pauseBackgroundMusic();
            }
        }

        updateVolumeUI(volume, unmuteState);

    }

    public void setBackgroundVolume(float volume) {
        this.backgroundMusic.volume = volume;
    }

    public void pauseBackgroundMusic() {
        unmuted = 0;
        this.backgroundMusic.Pause();
    }

    public void playBackgroundMusic() {
        unmuted = 1;
        this.backgroundMusic.Play();
    }

    public void saveSoundSettings(){
        PlayerPrefs.SetFloat("SavedVolume", this.backgroundMusic.volume);
        PlayerPrefs.SetInt("SavedMuteUnmute", unmuted);
    }

    public void updateVolumeUI(float volume, int unmuteState){
        if(volumeSlider == null || volumeOnButton == null || volumeOffButton == null) return;

        volumeSlider.value = volume;

        if(unmuteState==1){
            volumeOnButton.SetActive(true);
            volumeOffButton.SetActive(false);
        }else{
            volumeOnButton.SetActive(false);
            volumeOffButton.SetActive(true);
        }
    }
}
