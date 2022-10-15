using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text countdownText, pointsText;

    public void UpdateTimer(float currentTime) {
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        if (currentTime <= 10)
        {
            countdownText.color = Color.red;
        }
    }

    public void UpdateObjectiveStatus(ObjectiveStatus p)
    {
        pointsText.SetText(p.points.ToString());
        Debug.Log(p.collectItems["Can"]);
        // Add visualization of the objective here
    }
}
