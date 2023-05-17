using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
     public int startingLives = 3;
    public int currentLives;

    void Start()
    {
        currentLives = startingLives;
    }

    public void LoseLife()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            SceneManager.LoadScene("Start");
        }
    }
}









