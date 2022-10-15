using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ObjectiveStatus {
    public int points;
    public Dictionary<string, int> collectItems;
}

public class GameManager : MonoBehaviour
{
    public UIManager ui;

    private float currentTime, startingTime = 60f;
    private List<GameObject> subjects;
    private ObjectiveStatus objectiveStatus;

    void Start()
    {
        Spawner spawnerScript = GameObject.FindGameObjectWithTag("TrashSpawner").GetComponent<Spawner>();
        subjects = spawnerScript.subjects;
        currentTime = startingTime;
        this.AssignNewObjective(0, 0, 5);
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

    public void UpdateObjective(string id, int pointsAdd)
    {
        objectiveStatus.points += pointsAdd;
        if(objectiveStatus.collectItems[id] > 0)
            objectiveStatus.collectItems[id] = objectiveStatus.collectItems[id] - 1;
        
        ui.UpdateObjectiveStatus(objectiveStatus);
    }

    public void AssignNewObjective(int currentPoints, int min, int max) {
        Dictionary<string, int> collectItems = new Dictionary<string, int>();

        foreach (GameObject s in subjects) {
            ItemId itemIdScript = s.GetComponent<ItemId>();
            collectItems[itemIdScript.id] = Random.Range(min, max);
        }

        objectiveStatus = new ObjectiveStatus() {
            points = currentPoints,
            collectItems = collectItems,
        };
        ui.UpdateObjectiveStatus(objectiveStatus);
    }
}
