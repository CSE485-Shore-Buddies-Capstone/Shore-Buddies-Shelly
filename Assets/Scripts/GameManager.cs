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
    public LeaderboardHandler leaderboard;
    public float startingTime = 60f;

    private float currentTime;
    private int initialMin = 1, initialMax = 2;
    private List<GameObject> subjects;
    private ObjectiveStatus objectiveStatus;
    private int level = 1, pointsAtLevelBegin = 0;
    private SceneLoader sceneLoader;

    void Start()
    {
        ResumeGame();
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        Spawner spawnerScript = GameObject.FindGameObjectWithTag("TrashSpawner").GetComponent<Spawner>();
        subjects = spawnerScript.subjects;
        currentTime = startingTime;
        this.AssignNewObjective(0, initialMin, initialMax);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        ui.UpdateTimer(currentTime);
        if(currentTime < 0f) {
            GameOver();
        }
    }

    public void GameOver()
    {
        PauseGame();
        ui.UpdateFinalScores(level - 1, objectiveStatus.points);
        ui.ShowGameOver();
    }

    public void LoadHome() {
        sceneLoader.Load("Home");
    }

    public void ReloadGame() {
        sceneLoader.Load("FishingGame");
    }

    public void UpdateObjective(string id, int pointsAdd)
    {
        int pointMultiplier = level;
        objectiveStatus.points += pointsAdd * pointMultiplier;
        if(objectiveStatus.collectItems[id] > 0)
            objectiveStatus.collectItems[id] = objectiveStatus.collectItems[id] - 1;
        ui.UpdateObjectiveStatus(objectiveStatus);
        leaderboard.updateScore(objectiveStatus.points);

        bool allZero = true;
        foreach(KeyValuePair<string, int> entry in objectiveStatus.collectItems) {
            if(entry.Value > 0)
                allZero = false;
        }
        if(allZero) {
            PauseGame();
            ui.UpdateLevelScores(objectiveStatus.points - pointsAtLevelBegin, objectiveStatus.points, level);
            ui.ShowLevelResults();
        }
    }

    public void AssignNewObjective(int currentPoints, int min, int max) {
        Dictionary<string, int> collectItems = new Dictionary<string, int>();

        foreach (GameObject s in subjects) {
            ItemId itemIdScript = s.GetComponent<ItemId>();
            collectItems[itemIdScript.id] = Random.Range(min, max+1);
        }

        objectiveStatus = new ObjectiveStatus() {
            points = currentPoints,
            collectItems = collectItems,
        };
        ui.UpdateObjectiveStatus(objectiveStatus);
    }

    public void MoveNextLevel() {
        level += 1;
        currentTime = startingTime;
        pointsAtLevelBegin = objectiveStatus.points;
        if(level % 2 == 1)
            initialMin++;
        initialMax++;
        AssignNewObjective(objectiveStatus.points, initialMin, initialMax);
        ui.UpdateObjectiveStatus(objectiveStatus);
        ResumeGame();
    }

    public void PauseGame() {
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
    }
}
