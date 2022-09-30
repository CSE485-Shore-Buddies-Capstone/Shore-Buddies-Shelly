using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour
{
    [Header("UI")]
    public Button holdButton;
    
    [Header("Line Objects")]
    public GameObject catcher;
    public Transform origin;
    public Transform destination;
    public float lineSpeed = 15f;
    private LineRenderer line;
    private float counter;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, origin.position);
        distance = Vector3.Distance(origin.position, destination.position);
    }

    void Update()
    {
        // hook will always be at the end of the line
        catcher.transform.position = line.GetPosition(1);

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)){
            // reel
            if(counter < distance){
                counter += .1f / lineSpeed;
                float x = Mathf.Lerp(0, distance, counter);
                
                Vector3 pointA = origin.position;
                Vector3 pointB = destination.position;

                Vector3 pointAlongLine = x * Vector3.Normalize(pointB-pointA)+pointA;
                line.SetPosition(1, pointAlongLine);
            }
        }
        else{
            // release
            counter = 0;
            if(counter < distance){
                counter += .1f / lineSpeed;
                float x = Mathf.Lerp(0, distance, counter);
                
                Vector3 pointA = line.GetPosition(1);
                Vector3 pointB = origin.position;

                Vector3 pointAlongLine = x * Vector3.Normalize(pointB-pointA)+pointA;
                line.SetPosition(1, pointAlongLine);
            }
        }
    }
}
