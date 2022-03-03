using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject subject;
    public float timeBetween = 3f;
    public float timeTillNext = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeTillNext <= 0) {
            Instantiate(subject, transform.parent, true);
            timeTillNext = timeBetween;
        }
        timeTillNext -= Time.deltaTime;
    }
}
