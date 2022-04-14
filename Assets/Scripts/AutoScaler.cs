using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    public float subjectRatio = 0.25f;

    private float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = (float)(Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height);

        //ratio the size of the subject with the size of the screen
        autoScale(gameObject);
    }

    public float getScaler(float currentScale, float thisScreenWidth = -1) {
        SpriteRenderer r = gameObject.GetComponent<SpriteRenderer>();
        float spriteWidth = r.sprite.bounds.size.x;
        float currentRatio;
        if(thisScreenWidth != -1)
            currentRatio = spriteWidth/thisScreenWidth;
        else
            currentRatio = spriteWidth/screenWidth;
        float multFactor = currentScale/currentRatio;
        return multFactor;
    }

    private void autoScale(GameObject subject) {
        //ratio the size of the subject with the size of the screen
        SpriteRenderer r = subject.GetComponent<SpriteRenderer>();
        float spriteWidth = r.sprite.bounds.size.x;
        float currentRatio = spriteWidth/screenWidth;
        float multFactor = subjectRatio/currentRatio;
        subject.transform.localScale = new Vector3(multFactor,multFactor,multFactor);
    }
}
