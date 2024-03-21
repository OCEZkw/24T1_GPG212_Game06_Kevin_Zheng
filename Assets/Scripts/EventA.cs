using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventA : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI page1Text;
    public Button tradeFoodForWaterButton;
    public Button tradeWaterForFoodButton;
    public DaysManager daysManager;
    public ResourceManager resourceManager;

    private bool eventTriggered = false;

    public void TriggerEvent()
    {
        Debug.Log("Event A (Trader Visit) triggered!");

        // Display event text on page 1
        page1Text.text = "A trader is here! Would you like to trade 1 food for 2 water or 1 water for 2 food?";

        // Show the canvas
        canvas.SetActive(true);

        // Show the trade buttons
        tradeFoodForWaterButton.gameObject.SetActive(true);
        tradeWaterForFoodButton.gameObject.SetActive(true);

        // Set event triggered flag
        eventTriggered = true;
    }

    public void TradeFoodForWater()
    {
        if (resourceManager.CurrentFood >= 1)
        {
            // Trade 1 food for 1 water
            resourceManager.ConsumeResources(0, 1); // Consume 1 food
            resourceManager.AddResources(2, 0); // Add 1 water

            // Update the text on page 1 if needed
            page1Text.text = "Trade successful!";
        }
        else
        {
            page1Text.text = "Not enough food to trade!";
        }

        // Hide the trade buttons
        tradeFoodForWaterButton.gameObject.SetActive(false);
        tradeWaterForFoodButton.gameObject.SetActive(false);
    }

    public void TradeWaterForFood()
    {
        if (resourceManager.CurrentWater >= 1)
        {
            // Trade 1 water for 1 food
            resourceManager.ConsumeResources(1, 0); // Consume 1 water
            resourceManager.AddResources(0, 2); // Add 1 food

            // Update the text on page 1 if needed
            page1Text.text = "Trade successful!";
        }
        else
        {
            page1Text.text = "Not enough water to trade!";
        }

        // Hide the trade buttons
        tradeFoodForWaterButton.gameObject.SetActive(false);
        tradeWaterForFoodButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check if eventA is not triggered and hide the buttons if necessary
        if (!eventTriggered)
        {
            tradeFoodForWaterButton.gameObject.SetActive(false);
            tradeWaterForFoodButton.gameObject.SetActive(false);
        }
    }
    public void UpdatePage1Text(string newText)
    {
        page1Text.text = newText;
        tradeFoodForWaterButton.gameObject.SetActive(false);
        tradeWaterForFoodButton.gameObject.SetActive(false);
    }
    public bool IsEventTriggered()
    {
        return eventTriggered;
    }
}
