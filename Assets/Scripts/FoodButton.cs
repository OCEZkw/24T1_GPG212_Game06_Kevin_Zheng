using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodButton : MonoBehaviour
{
    public ResourceManager resourceManager;
    public DaysManager daysManager;

    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        if (resourceManager != null)
        {
            resourceManager.ConsumeResources(0, 1); // Consume 0 water and 1 food
            daysManager.NotifyFoodConsumed();
        }
        else
        {
            Debug.LogWarning("Resource Manager reference not set in FoodButton script.");
        }
    }
}
