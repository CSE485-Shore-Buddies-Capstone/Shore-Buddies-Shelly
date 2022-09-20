using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTimer : MonoBehaviour
{
    public float deleteTimer = 10f;

    // Update is called once per frame
    void Update()
    {
        deleteTimer -= Time.deltaTime;
        if(deleteTimer <= 0)
            GameObject.Destroy(gameObject);
    }
}
