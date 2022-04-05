using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

//THIS SCRIPT IS CALLED WHENEVER WE HAVE TO LIVE UPDATE THE UI AT ANY POINT (points, lives, levels, etc.)
public class UIManager : MonoBehaviour
{

    private GameObject pointsObject;
    private GameObject livesObject;

    private GameManager GM;

    //This needs to be AWAKE not START. AWAKE runs BEFORE START, and the UI needs to be initialized early.
    void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        pointsObject = GameObject.FindGameObjectWithTag("Points");
        livesObject = GameObject.FindGameObjectWithTag("Lives");
    }

    void Update()
    {
        
    }


    public void UpdateUI()
    {
        pointsObject.GetComponent<TMP_Text>().SetText("Points: " + GM.getPoints().ToString());
        ManageLives(GM.getLives());
    }

    private void ManageLives(int lives)
    {
        foreach(Transform life_tf in livesObject.transform)
        {
            if (int.Parse(life_tf.name) >= lives)
            {
                life_tf.gameObject.SetActive(false);
                
            }
        }
    }
}
