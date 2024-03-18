using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaysManager : MonoBehaviour
{
    public int currentDay = 1;
    public int totalDays = 5; // Change this to the total number of days in your game

    public void IncrementDay()
    {
        if (currentDay < totalDays)
        {
            currentDay++;
            Debug.Log("Day " + currentDay);
        }
        else
        {
            Debug.Log("Game Over"); // Or any other game over logic
        }
    }

    public void EndDay()
    {
        IncrementDay(); // Increment the day
        SceneManager.LoadScene("YourNextDaySceneName"); // Load the next day scene
    }
}
