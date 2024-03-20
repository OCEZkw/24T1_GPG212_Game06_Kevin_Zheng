using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMission : MonoBehaviour
{
    public ResourceManager resourceManager;
    public DaysManager daysManager;

    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        if (resourceManager != null && daysManager != null)
        {
            daysManager.SendDogOnMission(resourceManager);
        }
        else
        {
            Debug.LogWarning("Resource Manager or Days Manager reference not set in DogReturnButton script.");
        }
    }
}
