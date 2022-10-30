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
    public float maxCastDurationSeconds = 3f;

    private LineRenderer line;
    private float percentOfDistance = 0;
    private float distance;
    private bool casted, locked;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();

        // set line to fish line's initial position
        line.SetPosition(0, this.transform.position);
        // line.SetPosition(1, this.transform.position);
        
        distance = Vector3.Distance(origin.position, destination.position);
    }

    void Update()
    {
        // hook will always be at the end of the line
        catcher.transform.position = line.GetPosition(1);
        
        if (casted && !locked){
            // cast
            if(percentOfDistance < 1.0f){
                percentOfDistance += Time.deltaTime / maxCastDurationSeconds;
                setLinePosition(percentOfDistance);
            }
            else
                casted = false;
        }
        else {
            // reel
            locked = true;
            if(percentOfDistance > 0){
                percentOfDistance -= Time.deltaTime / maxCastDurationSeconds;
                setLinePosition(percentOfDistance);
            }
            else
                locked = false;
        }
    }

    public void CastReel() {
        if(!locked)
            casted = true;
    }

    public void BringReelBack() {
        casted = false;
        locked = true;
    }

    private void setLinePosition(float percentageThrough) {
        float percentedPoint = Mathf.Lerp(0, distance, percentageThrough);
        Vector3 pointAlongLine = (percentedPoint * Vector3.Normalize(destination.position-origin.position ))+origin.position;
        line.SetPosition(1, pointAlongLine);
    }
}
