using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager2 : MonoBehaviour
{
    private GameObject pointsObject;
    private GameManager gm;

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager2").GetComponent<GameManager>();

        pointsObject = GameObject.FindGameObjectWithTag("Points");
    }

    public void UpdateUI()
    {
        pointsObject.GetComponent<TMP_Text>().SetText("Objective: " + gm.getPoints().ToString());
    }

}
