using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gm;
    public GameObject pointsObject;

    public void UpdateUI()
    {
        pointsObject.GetComponent<TMP_Text>().SetText("Objective: " + gm.getPoints().ToString());
    }

}
