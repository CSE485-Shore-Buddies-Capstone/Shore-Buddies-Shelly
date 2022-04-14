using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
  public float speed = 10.4f;

  private Camera mainCamera;
  private Vector3 pointTopLeft;
  private Vector3 pointTopRight;
  private AutoScaler autoScalerScript;

  void Start() {
    autoScalerScript = gameObject.GetComponent<AutoScaler>();
    speed *= autoScalerScript.getScaler(1f);
    mainCamera = Camera.main;
    pointTopLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
    pointTopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane));
  }
  
  // Update is called once per frame
  void Update()
  {
    Vector3 pos = transform.position;

    if(Input.GetKey("a"))
    {
      float newPos = pos.x - speed * Time.deltaTime;
      if(newPos > pointTopLeft.x) {
        pos.x = newPos;
      }
    }
    if(Input.GetKey("d"))
    {
      float newPos = pos.x + speed * Time.deltaTime;
      if(newPos < pointTopRight.x) {
        pos.x = newPos;
      }
    }
    transform.position = pos;  
  }
}
