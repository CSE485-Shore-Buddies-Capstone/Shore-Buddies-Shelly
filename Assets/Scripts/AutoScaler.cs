using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    public float subjectRatio = 0.25f;

    private Camera mainCamera;
    private float screenWidth;
    private Vector2 res;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        res = new Vector2(Screen.width, Screen.height);
        screenWidth = (float)(mainCamera.orthographicSize * 2.0 * Screen.width / Screen.height);

        //ratio the size of the subject with the size of the screen
        autoScale(gameObject);
    }

    public float getScaler(float currentScale) {
        SpriteRenderer r = gameObject.GetComponent<SpriteRenderer>();
        float spriteWidth = r.sprite.bounds.size.x;
        float currentRatio = spriteWidth/screenWidth;
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
