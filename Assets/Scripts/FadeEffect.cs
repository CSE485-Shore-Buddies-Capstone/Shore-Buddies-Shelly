using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ref: https://www.youtube.com/watch?v=YYD_tBBS4FY
public class FadeEffect : MonoBehaviour
{
    public float Duration;
    public CanvasGroup canvGroup;
    public bool solidStart; //switch this ON if you want to put on a panel fader script for new scene transitions

    void Awake(){
        canvGroup = GetComponent<CanvasGroup>();

        if(solidStart){
            FadeExit();
        }
    }

    void OnEnable(){
        if(solidStart!=true)
            FadeEnter(); 
    }

    //from alpha 1 to 0 (transitions OUT of a solid color)
    public void FadeEnter()
    {
        canvGroup.alpha = 0;
        canvGroup.gameObject.SetActive(true);
        StartCoroutine(DoFade(canvGroup, 0f, 1f));
        
    }

    //from alpha 1 to 0 (transitions INTO a solid color)
    public void FadeExit()
    {
        StartCoroutine(DoFade(canvGroup, 1f, 0f));
    }

    //loop in couroutine
    private IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float count = 0f;

        while (count < Duration)
        {
            count += Time.deltaTime; //use delta time with counter
            canvGroup.alpha = Mathf.Lerp(start, end, count / Duration);
            yield return null;
        }

        //Debug.Log("PanelFinder::this gets called after duration is reached / end of coroutine");
        if (end == 0) //if ends with 0 alpha
            canvGroup.gameObject.SetActive(false);
    }

       // //method has this object fade in and out on button click
    // public void FadeInOut()
    // {
    //     var canvGroup = GetComponent<CanvasGroup>();

    //     StartCoroutine(DoFade(canvGroup, canvGroup.alpha, faded ? 1 : 0));
    //     //toggle fade state
    //     faded = !faded;

    // }
}
