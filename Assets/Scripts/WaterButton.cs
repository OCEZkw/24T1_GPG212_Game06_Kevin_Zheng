using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterButton : MonoBehaviour
{
    public ResourceManager resourceManager;

    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        if (resourceManager != null)
        {
            resourceManager.UseWater(); // Call UseWater method from ResourceManager
        }
        else
        {
            Debug.LogWarning("Resource Manager reference not set in WaterButton script.");
        }
    }
}
