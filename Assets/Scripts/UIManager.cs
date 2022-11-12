using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public List<GameObject> collectablesUI;
    public TMP_Text countdownText, pointsText;
    public TMP_Text levelPassedDisplay, pointsEarned, totalPoints;
    public TMP_Text finalLevelPassedDisplay, finalPointsEarned;
    public TMP_Text levelText;
    public GameObject collectionHolder;
    public GameObject levelDisplayPanel, gameOverPanel;
    public BackgroundController bkgndController;

    private List<GameObject> collectablesUIInstantiated = new List<GameObject>();

    void Start() {
        bkgndController = FindObjectOfType<BackgroundController>();
        foreach (Transform child in collectionHolder.transform) {
            GameObject.Destroy(child.gameObject);
        }
        foreach (GameObject c in collectablesUI) {
            GameObject collectable = Instantiate(c, collectionHolder.transform);
            collectablesUIInstantiated.Add(collectable);
        }
    }

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
        else
            countdownText.color = Color.black;
    }

    public void UpdateObjectiveStatus(ObjectiveStatus p)
    {
        pointsText.SetText(p.points.ToString());
        
        foreach(GameObject c in collectablesUIInstantiated) {
            ItemId idScript = c.GetComponent<ItemId>();
            if(p.collectItems[idScript.id] <= 0) {
                // turn on checkmark
                c.transform.GetChild(3).gameObject.SetActive(true);
                // turn off text
                c.transform.GetChild(2).gameObject.SetActive(false);
            }
            else { // update otherwise
                c.transform.GetChild(3).gameObject.SetActive(false);
                c.transform.GetChild(2).gameObject.SetActive(true);
                TMP_Text itemText = c.GetComponentInChildren<TMP_Text>();
                itemText.SetText("x" + p.collectItems[idScript.id].ToString());
            }
        }
    }

    public void UpdateLevelScores(int pEarned, int pTotal, int level) {
        pointsEarned.SetText("Points Earned: " + pEarned.ToString());
        totalPoints.SetText("Total Points: " + pTotal.ToString());
        levelPassedDisplay.SetText("You passed level " + level.ToString() + "!");
    }

    public void UpdateFinalScores(int level, int pTotal) {
        finalLevelPassedDisplay.SetText("Levels Passed: " + level.ToString());
        finalPointsEarned.SetText("Final Score: " + pTotal.ToString());
    }
    public void UpdateLevelText(int level){
        levelText.text = "Level " + level;
        levelText.GetComponent<FadeEffect>().FadeEnter();
    }
    public void UpdateBackground(){
        bkgndController.NextBackground();
    }
    public void ShowGameOver() {
        gameOverPanel.SetActive(true);
    }

    public void ShowLevelResults() {
        levelDisplayPanel.SetActive(true);
    }
}
