using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> subjects;
    public float[] timeBetweenRange = new float[2];
    public float timeTillNext = 1f;
    
    private Camera mainCamera;
    private Vector3 pointTopLeft;
    private Vector3 pointTopRight;
    private Vector2 res;

    void Start() {
        mainCamera = Camera.main;
        res = new Vector2(Screen.width, Screen.height);
        setScreenConstants();
    }

    // Update is called once per frame
    void Update()
    {
        if (res.x != Screen.width || res.y != Screen.height) {
            setScreenConstants();
        }
        if(timeTillNext <= 0) {
            float xSpawn = Random.Range(pointTopLeft.x, pointTopRight.x);
            float ratioAboveScreen = 5f/4f;
            Vector3 thisLocation = new Vector3(xSpawn, -pointTopLeft.y * ratioAboveScreen, 0f);
            Instantiate(subjects[Random.Range(0, subjects.Count)], thisLocation, new Quaternion());
            timeTillNext = Random.Range(timeBetweenRange[0], timeBetweenRange[1]);
        }
        timeTillNext -= Time.deltaTime;
    }

    private void setScreenConstants() {
        pointTopLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        pointTopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane));
    }
}
