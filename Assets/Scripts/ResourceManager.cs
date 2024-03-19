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

    private int currentWater;
    private int currentFood;

    public TextMeshProUGUI waterText; // TextMeshProUGUI component for displaying water
    public TextMeshProUGUI foodText;  // TextMeshProUGUI component for displaying food

    void Start()
    {
        currentWater = startingWater;
        currentFood = startingFood;

        UpdateResourceUI(); // Update UI when the game starts
    }

    public void ConsumeResources(int waterAmount, int foodAmount)
    {
        currentWater -= waterAmount;
        currentFood -= foodAmount;

        UpdateResourceUI();
    }

    public void UpdateResourceUI()
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
