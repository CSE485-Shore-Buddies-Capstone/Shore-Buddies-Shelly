using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> subjects;
    public float[] timeBetweenRange = new float[2];
    public float timeTillNext = 1f;
    
    private Camera mainCamera;
    private Vector3 pointTopLeft, pointTopRight, pointBottomRight, pointBottomLeft;
    private Vector2 res;
    // private float[] screenRange = new float[]{0.2f, 1f};

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
            {
                
                Vector3 middle = (pointTopLeft + pointBottomLeft) / 2;
                float ySpawnOffset = Random.Range(middle.y, pointBottomLeft.y);
                float ratioOffScreen = 5f/4f;
                Vector3 thisLocation = new Vector3(pointTopLeft.x * ratioOffScreen, middle.y - 0.9f * ySpawnOffset, 0f);
                Instantiate(subjects[Random.Range(0, subjects.Count)], thisLocation, new Quaternion());
            }
            {
                Vector3 middle = (pointTopRight + pointBottomRight) / 2;
                float ySpawnOffset = Random.Range(middle.y, pointBottomRight.y);
                float ratioOffScreen = 5f/4f;
                Vector3 thisLocation = new Vector3(pointTopRight.x * ratioOffScreen, middle.y - 0.9f * ySpawnOffset, 0f);
                GameObject trash = Instantiate(subjects[Random.Range(0, subjects.Count)], thisLocation, new Quaternion());
                trash.GetComponent<TrashMovement>().direction = Vector3.left;
            }
            timeTillNext = Random.Range(timeBetweenRange[0], timeBetweenRange[1]);
        }
        timeTillNext -= Time.deltaTime;
    }

    private void setScreenConstants() {
        pointTopLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        pointTopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane));
        pointBottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, mainCamera.nearClipPlane));
        pointBottomRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));
    }
}
