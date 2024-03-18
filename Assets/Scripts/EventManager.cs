using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public EventA eventA; // Reference to EventA script
    public EventB eventB; // Reference to EventB script
    // Add more event references as needed

    public void TriggerRandomEvent()
    {
        int randomEvent = Random.Range(1, 3); // Change 3 to the total number of events
        switch (randomEvent)
        {
            case 1:
                eventA.TriggerEvent();
                break;
            case 2:
                eventB.TriggerEvent();
                break;
            // Add cases for more events
            default:
                Debug.Log("No event triggered");
                break;
        }
    }
}
