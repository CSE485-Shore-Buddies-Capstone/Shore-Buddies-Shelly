using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    private int points;
    private UIManager ui;

    void Start()
    {
        ui = GetComponent<UIManager>();
        points = 0;
        ui.UpdateUI();
    }

    void GAME_OVER()
    {
        Debug.Log("You lose the game!");
        SceneLoader.Load("SampleHome");
    }

    public void addPoints(int pointsAdd)
    {
        points += pointsAdd;
        ui.UpdateUI();
    }

    public int getPoints()
    {
        return points;
    }
}
