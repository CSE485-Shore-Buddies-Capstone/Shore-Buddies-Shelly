using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int points;
    private int lives;

    void Start()
    {
        points = 0;
        lives = 5; // we'll figure out a system to take care init lives
    }

    void GAME_OVER()
    {
        Debug.Log("YOU HAVE DIED");

        //going to menu now, change later to bring up game over menu
        SceneLoader.Load("Menu");
    }

    //GETTERS AND SETTERS
    
    public void addPoints(int numberOfPoints)
    {
        points += numberOfPoints;
    }

    public int getPoints()
    {
        return points;
    }

    public void removeLives(int numberOfLives)
    {
        lives -= numberOfLives;
    }

    public int getLives()
    {
        return lives;
    }

    void Update()
    {
        //init game over sequence if player runs out of lives
        if(lives <= 0)
        {
            GAME_OVER();
        }
    }
}
