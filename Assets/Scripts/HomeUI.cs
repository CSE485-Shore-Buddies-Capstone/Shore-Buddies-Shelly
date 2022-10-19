using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    [Header("UI")]
    public Button playButton;

    [Header("Page Transition")]
    public Animator transition;
    public float transitionTime;
    //public GameObject bubbleEffect; //TODO: still working on it

    private SceneLoader sceneLoader;

    void Start(){
        Time.timeScale = 1;
        playButton.onClick.AddListener(PlayGameWrap);
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
    }

    //wrapper to call the coroutined transition when play button is clicked
    private void PlayGameWrap(){
        StartCoroutine(PlayGame());
    }

    private IEnumerator PlayGame(){
        // bubbleEffect.SetActive(true);
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
        sceneLoader.Load("FishingGame");
    }
}
