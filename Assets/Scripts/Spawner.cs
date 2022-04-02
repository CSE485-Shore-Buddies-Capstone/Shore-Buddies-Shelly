using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> subjects;
    public List<Transform> spawnLocations;
    public float[] timeBetweenRange = new float[2];
    public float timeTillNext = 1f;

    // Update is called once per frame
    void Update()
    {
        if(timeTillNext <= 0) {
            Transform thisLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
            Instantiate(subjects[Random.Range(0, subjects.Count)], thisLocation.position, thisLocation.rotation);
            timeTillNext = Random.Range(timeBetweenRange[0], timeBetweenRange[1]);
        }
        timeTillNext -= Time.deltaTime;
    }
}
