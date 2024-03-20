using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterButton : MonoBehaviour
{
    public ResourceManager resourceManager;
    public DaysManager daysManager;

    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        if (resourceManager != null)
        {
            resourceManager.ConsumeResources(1, 0); // Consume 1 water and 0 food
            daysManager.NotifyWaterConsumed();
        }
        else
        {
            Debug.LogWarning("Resource Manager reference not set in WaterButton script.");
        }
    }
}
