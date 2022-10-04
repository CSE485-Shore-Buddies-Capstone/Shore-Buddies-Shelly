using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text countdownText;
    public UIManager ui;
    private int points = 0;
    private float currentTime = 0f, startingTime = 60f;

    void Start()
    {
        currentTime = startingTime;
        ui.UpdateUI();
    }
    
    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
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

    public void GAME_OVER()
    {
        Debug.Log("You lose the game!");
        SceneLoader.Load("Home");
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
