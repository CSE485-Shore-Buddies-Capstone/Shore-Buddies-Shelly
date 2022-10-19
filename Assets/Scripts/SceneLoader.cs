using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    [Header("Page Transition")]
    public Animator transition;
    public float transitionTime = 4f;
    public GameObject canvas;

    void Start(){
        canvas.SetActive(false);
    }

    //will temporarily take in string scene (move onto enum later)
    public void Load(string scene){
        canvas.SetActive(true);
        StartCoroutine(LoadRoutine(scene));
    }

    private IEnumerator LoadRoutine(string scene){
        // bubbleEffect.SetActive(true);
        transition.SetTrigger("FadeOut");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(scene);
    }
}
