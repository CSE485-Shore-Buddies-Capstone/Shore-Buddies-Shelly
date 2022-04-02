using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
  public float speed = 10.4f;
    // Update is called once per frame
    void Update()
    {
      Vector3 pos = transform.position;

      if(Input.GetKey("a"))
      {
        pos.x -= speed * Time.deltaTime;
      }
      if(Input.GetKey("d"))
      {
        pos.x += speed * Time.deltaTime;
      }
      transform.position = pos;  
    }
}