using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public EventA eventA; // Reference to EventA script
    public EventB eventB; // Reference to EventB script
    public EventC eventC;
    public EventD eventD;

    // Add more event references as needed

    public void TriggerRandomEvent()
    {
        // Generate a random number between 0 and 99
        int randomNumber = Random.Range(0, 100);

        if (randomNumber < 32)
        {
            eventA.TriggerEvent();
        }
        else if (randomNumber < 64)
        {
            eventB.TriggerEvent();
        }
        else if (randomNumber < 96)
        {
            eventC.TriggerEvent();
        }
        else // 4% chance
        {
            eventD.TriggerEvent();
        }
    }
}
