using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// for the sky and the birds...
public class BackgroundController : MonoBehaviour
{
    public Image[] skyList;
    public GameObject[] birdsList;
    public float fadeSpeed;
    private int skyIndex;

    void Start()
    {
        skyIndex = 0;
        fadeSpeed = 1f;
        InvokeRepeating("RandomizeBirds", 5.0f, 10f); // spawn the birds!!
    }

    // iterate through sky list at random
    public void RandomizeBackground(){
        Image previousSky = skyList[skyIndex];
        int newSkyIndex = Random.Range(0, skyList.Length);
        // makes sure that color is unique
        while(skyIndex == newSkyIndex){
            newSkyIndex = Random.Range(0, skyList.Length);
        }
        Image newSky = skyList[newSkyIndex];
        Change(previousSky, newSky);
    }

    public void RandomizeBirds(){
        int numBirdsToSpawn = Random.Range(0, birdsList.Length+1); // [0-2]
        if(numBirdsToSpawn == 0){
            return;
        }else{
            for(int i = 0; i <= numBirdsToSpawn-1; i++){
                birdsList[i].GetComponent<ImageMovement>().RandomizeMovement();
            }
        }
    }

    // iterate through sky list in order
    public void NextBackground(){
        Image previousSky = skyList[skyIndex];
        
        if(skyIndex == skyList.Length-1){
            skyIndex=0;
        }else{
            skyIndex++;
        }
        
        Image newSky = skyList[skyIndex];
        Change(previousSky, newSky);
    }

    private void Change(Image previousSky, Image newSky){
        // update alpha value for previous sky
        if(previousSky.color.a == 0){
             StartCoroutine(Fade(previousSky, 1f, fadeSpeed));
        }else{
            StartCoroutine(Fade(previousSky, 0f, fadeSpeed));

        }

        // update alpha value for new sky
        if(newSky.color.a == 0){
            StartCoroutine(Fade(newSky, 1f, fadeSpeed));
        }else{
            StartCoroutine(Fade(newSky, 0f, fadeSpeed));
        }
    }

    // reference: https://answers.unity.com/questions/1687634/how-do-i-mathflerp-the-spriterendereralpha.html
    public IEnumerator Fade(Image sr, float endValue, float duration)
    {
        float elapsedTime = 0;
        float startValue = sr.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
    }
}
