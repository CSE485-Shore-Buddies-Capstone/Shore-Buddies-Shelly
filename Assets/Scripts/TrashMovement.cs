using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour
{
    public float speed = 3f;
    public float acceleration = 0f;
    public Vector3 direction = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += direction * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;
    }
}
