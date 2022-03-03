using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 10f;
    public float fallAcceleration = 0f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= transform.up * fallSpeed * Time.deltaTime;
        fallSpeed += fallAcceleration * Time.deltaTime;
    }
}
