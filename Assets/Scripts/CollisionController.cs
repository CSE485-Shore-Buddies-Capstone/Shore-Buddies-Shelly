using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private GameManager GM;

    void Start()
    {
        // GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.tag == "Player")
        // {
        //     if(this.tag == "Star"){
        //         GM.AddLives(1);
        //     }else{
        //         GM.addPoints(1);
        //     }
        // }else if(collision.tag == "TrashMissedZone")
        // {
        //     Debug.Log("lskdjflsdkjf");
        //     if(this.tag == "Star"){
        //         //do nothing
        //     }else{
        //         GM.removeLives(1);
        //     }
        // }
        // else
        // {
        //     Debug.Log(collision.tag);
        // }

        // Destroy(gameObject);
    }
}
