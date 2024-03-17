using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public int startingWater = 6;
    public int startingFood = 6;

    private int currentWater;
    private int currentFood;

    public Text waterText;
    public Text foodText;

    void Start()
    {
        currentWater = startingWater;
        currentFood = startingFood;

        UpdateUI();
    }

    void Update()
    {
        // Example: Decrease resources over time
        // Adjust this according to your game's mechanics
        // For simplicity, let's assume resources decrease by 1 every second
        if (Time.timeSinceLevelLoad % 1 == 0)
        {
            ConsumeResources(1, 1);
        }
    }

    public void ConsumeResources(int waterAmount, int foodAmount)
    {
        currentWater -= waterAmount;
        currentFood -= foodAmount;

        UpdateUI();

        if (currentWater <= 0 || currentFood <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        waterText.text = "Water: " + currentWater;
        foodText.text = "Food: " + currentFood;
    }

    void GameOver()
    {
        // Implement game over logic here
        Debug.Log("Game Over!");
    }
}
