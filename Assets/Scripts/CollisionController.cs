using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private GameManager gm;
    private LineController lineController;
    private TrashMovement trashMovement;
    private bool caught;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        lineController = FindObjectOfType<LineController>();
        trashMovement = GetComponent<TrashMovement>();
        caught = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Catcher"){
            gm.UpdatePointObjective(1);
            trashMovement.RotateRandomly();
            caught = true;
        }
        else if(collision.gameObject.tag == "Trash"){
            // do nothing
        }
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if(caught){
            this.transform.position = lineController.catcher.transform.position;
            if(this.transform.position == lineController.origin.position){
                caught=false;
                Destroy(gameObject);
            }
        }
    }
}
