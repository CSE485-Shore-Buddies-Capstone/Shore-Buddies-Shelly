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
            spawnFrom(pointTopLeft, pointBottomLeft, Vector3.right);
            spawnFrom(pointTopRight, pointBottomRight, Vector3.left);
            timeTillNext = Random.Range(timeBetweenRange[0], timeBetweenRange[1]);
        }
        timeTillNext -= Time.deltaTime;
    }

    private void spawnFrom(Vector3 top, Vector3 bottom, Vector3 direction) {
        Vector3 middle = bottom + (top - bottom) * 0.5f;
                
        if (SystemInfo.deviceType == DeviceType.Handheld) { // different for handheld
            middle = bottom + (top - bottom) * 0.6f;
        }

        float ySpawnOffset = Random.Range(bottom.y, middle.y);
        float ratioOffScreen = 5f/4f;

        Vector3 thisLocation = new Vector3(top.x * ratioOffScreen, ySpawnOffset, 0f);
        GameObject trash = Instantiate(subjects[Random.Range(0, subjects.Count)], thisLocation, new Quaternion());
        trash.GetComponent<TrashMovement>().direction = direction;
    }

    private void setScreenConstants() {
        pointBottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        pointBottomRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane));
        pointTopLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, mainCamera.nearClipPlane));
        pointTopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));
    }
}
