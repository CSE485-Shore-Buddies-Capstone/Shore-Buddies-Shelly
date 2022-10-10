using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager ui;

    private float currentTime, startingTime = 60f;
    private ObjectiveStatus objectiveStatus = new ObjectiveStatus() {
        points = 0,
    };

    void Start()
    {
        currentTime = startingTime;
        ui.UpdateObjectiveStatus(objectiveStatus);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        ui.UpdateTimer(currentTime);
        if(currentTime < 0f) {
            SceneLoader.Load("Home");
        }
    }

    public void GameOver()
    {
        SceneLoader.Load("Home");
    }

    public void UpdatePointObjective(int pointsAdd)
    {
        objectiveStatus.points += pointsAdd;
        ui.UpdateObjectiveStatus(objectiveStatus);
    }
}
