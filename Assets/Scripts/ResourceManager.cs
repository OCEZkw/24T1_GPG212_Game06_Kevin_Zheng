using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;
using TMPro;


public class ResourceManager : MonoBehaviour
{
    public int startingWater = 6;
    public int startingFood = 6;

    public int CurrentWater { get; private set; }
    public int CurrentFood { get; private set; }

    public TextMeshProUGUI waterText; // TextMeshProUGUI component for displaying water
    public TextMeshProUGUI foodText;  // TextMeshProUGUI component for displaying food

    void Start()
    {
        CurrentWater = startingWater;
        CurrentFood = startingFood;

        UpdateResourceUI(); // Update UI when the game starts
    }

    public void ConsumeResources(int waterAmount, int foodAmount)
    {
        if (CurrentWater - waterAmount >= 0 && CurrentFood - foodAmount >= 0)
        {
            CurrentWater -= waterAmount;
            CurrentFood -= foodAmount;
        }
        else
        {
            // If the consumption would result in negative values, set the amounts to 0 instead
            CurrentWater = Mathf.Max(CurrentWater - waterAmount, 0);
            CurrentFood = Mathf.Max(CurrentFood - foodAmount, 0);
        }

        UpdateResourceUI();
    }

    public void UpdateResourceUI()
    {
        waterText.text = "Water: " + CurrentWater;
        foodText.text = "Food: " + CurrentFood;
    }

    void GameOver()
    {
        // Implement game over logic here
        Debug.Log("Game Over!");
    }

    public void AddResources(int waterAmount, int foodAmount)
    {
        CurrentWater += waterAmount;
        CurrentFood += foodAmount;
        UpdateResourceUI();
    }
}
