using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventC : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI page1Text;
    public Button openPackageButton;
    public Button disposePackageButton;

    public bool packageOpened = false;
    public bool packageDisposed = false;

    public ResourceManager resourceManager;
    public DaysManager daysManager;

    public void TriggerEvent()
    {
        Debug.Log("Event C (Mysterious Package) triggered!");

        // Display event text on page 1
        page1Text.text = "A mysterious package arrives at your doorstep with no sender information. It emits a faint ticking sound. What will you do?";

        // Show the canvas
        canvas.SetActive(true);

        // Show the choice buttons
        openPackageButton.gameObject.SetActive(true);
        disposePackageButton.gameObject.SetActive(true);
    }

    public void OpenPackage()
    {
        float randomChance = Random.value; // Generate a random float between 0 and 1

        if (randomChance <= 0.7f)
        {
            // 70% chance to gain +1 water and food
            resourceManager.AddResources(1, 1);
            page1Text.text = "You open the package and find valuable supplies inside. You gain +1 water and +1 food.";
        }
        else
        {
            // 30% chance the bomb goes off and player dies
            page1Text.text = "You open the package and it explodes, killing you instantly.";
            daysManager.playerDeath = true; // Set playerDeath to true
        }

        // Disable the buttons after a choice is made
        openPackageButton.gameObject.SetActive(false);
        disposePackageButton.gameObject.SetActive(false);
    }

    public void DisposePackage()
    {
        packageDisposed = true;
        page1Text.text = "You decide to dispose of the package without opening it. It turns out to be harmless, but you miss out on valuable supplies.";

        // Disable the buttons after a choice is made
        openPackageButton.gameObject.SetActive(false);
        disposePackageButton.gameObject.SetActive(false);
    }

    private void Start()
    {
        // Hide the choice buttons on start
        openPackageButton.gameObject.SetActive(false);
        disposePackageButton.gameObject.SetActive(false);
    }
    public bool IsPackageOpened()
    {
        return packageOpened;
    }
    public bool IsPackageDisposed()
    {
        return packageDisposed;
    }
    public void UpdatePage1Text(string newText)
    {
        page1Text.text = newText;
        openPackageButton.gameObject.SetActive(false);
        disposePackageButton.gameObject.SetActive(false);
    }

}
