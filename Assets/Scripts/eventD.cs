using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventD : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI page1Text;
    public Button evacuateButton;
    public Button stayButton;

    public DaysManager daysManager;

    public bool evacuateChosen = false;
    public bool stayChosen = false;

    public void TriggerEvent()
    {
        Debug.Log("Event D (Rescue Team) triggered!");

        // Display event text on page 1
        page1Text.text = "The rescue team has arrived to take you to the evacuation zone. Will you evacuate or stay?";

        // Show the canvas
        canvas.SetActive(true);

        // Show the choice buttons
        evacuateButton.gameObject.SetActive(true);
        stayButton.gameObject.SetActive(true);
    }

    public void Evacuate()
    {
        evacuateChosen = true;
        stayChosen = false;
        // Implement evacuation logic
        page1Text.text = "You decide to evacuate and leave the area with the rescue team.";


        // Hide the buttons after a choice is made
        evacuateButton.gameObject.SetActive(false);
        stayButton.gameObject.SetActive(false);
    }

    public void Stay()
    {
        stayChosen = true;
        evacuateChosen = false;
        // Implement stay logic
        page1Text.text = "You decide to stay. The rescue team leaves, and you continue to survive on your own.";

        // Hide the buttons after a choice is made
        evacuateButton.gameObject.SetActive(false);
        stayButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        // Hide the choice buttons on start
        evacuateButton.gameObject.SetActive(false);
        stayButton.gameObject.SetActive(false);
    }
    public bool IsStayChosen()
    {
        return stayChosen;
    }
    public void UpdatePage1Text(string newText)
    {
        page1Text.text = newText;
    }
}
