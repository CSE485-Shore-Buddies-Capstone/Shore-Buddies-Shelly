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

    void Start(){
        playButton.onClick.AddListener(PlayGameWrap);
    }

    //wrapper to call the coroutined transition when play button is clicked
    private void PlayGameWrap(){
        StartCoroutine(PlayGame());
    }

    private IEnumerator PlayGame(){
        // bubbleEffect.SetActive(true);
        transition.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
        SceneLoader.Load("CatchingGame");
    }
}
