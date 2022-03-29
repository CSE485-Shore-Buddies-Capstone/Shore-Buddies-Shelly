using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> subjects;
    public float[] timeBetweenRange = new float[2];
    public float timeTillNext = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeTillNext <= 0) {
            int rand_index = Random.Range(0, subjects.Count);
            Instantiate(subjects[rand_index], this.transform.position, this.transform.rotation);
            timeTillNext = Random.Range(timeBetweenRange[0], timeBetweenRange[1]);
        }
        timeTillNext -= Time.deltaTime;
    }
}
