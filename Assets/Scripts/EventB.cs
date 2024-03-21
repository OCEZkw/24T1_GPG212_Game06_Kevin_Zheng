using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventB : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI page1Text;
    public Button letThemInButton;
    public Button dontLetThemInButton;

    public bool letThemIn = false;
    public bool dontLetThemIn = false;

    public void TriggerEvent()
    {
        Debug.Log("Event B (People Asking for Help) triggered!");

        // Display event text on page 1
        page1Text.text = "People are knocking on the door, asking for help. What will you do?";

        // Show the canvas
        canvas.SetActive(true);

        // Show the choice buttons
        letThemInButton.gameObject.SetActive(true);
        dontLetThemInButton.gameObject.SetActive(true);
    }

    public void LetThemIn()
    {
        letThemIn = true;
        dontLetThemIn = false; // Ensure only one button is true at a time
        page1Text.text = "You have chosen to let them in. The outcome will be revealed tomorrow.";
    }

    public void DontLetThemIn()
    {
        letThemIn = false; // Ensure only one button is true at a time
        dontLetThemIn = true;
        page1Text.text = "You have chosen not to let them in. The outcome will be revealed tomorrow.";
    }

    private void Start()
    {
        // Hide the choice buttons on start
        letThemInButton.gameObject.SetActive(false);
        dontLetThemInButton.gameObject.SetActive(false);
    }
}
