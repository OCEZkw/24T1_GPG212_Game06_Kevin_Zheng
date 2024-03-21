using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DogCharacter : MonoBehaviour
{
    public int startingHunger = 10;
    public int startingThirst = 10;

    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI thirstText;

    private int currentHunger;
    private int currentThirst;

    public Image dogImage;
    public Sprite deadSprite;
    public Sprite normalSprite;
    public Sprite onMissionSprite;

    public TextMeshProUGUI page3Text;
    public TextMeshProUGUI page1Text;

    public Button scavengeButton;

    void Start()
    {
        currentHunger = startingHunger;
        currentThirst = startingThirst;

        page3Text.gameObject.SetActive(false);
        page1Text.gameObject.SetActive(false);

        UpdateUI();
    }

    void Update()
    {
        if (currentHunger <= 0 || currentThirst <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        dogImage.sprite = deadSprite;

        scavengeButton.interactable = false;

        // Check if the dog is dead
        if (currentHunger <= 0 || currentThirst <= 0)
        {
            // Update the canvas text for page3 if the dog is dead
            page3Text.text = "Your faithful companion has passed away. The journey just got a lot lonelier.";
            // Show the text
            page3Text.gameObject.SetActive(true);
        }
    }

    public void DecreaseStats()
    {
        int hungerDecrease = Random.Range(1, 5); // Decrease hunger by random amount between 1 and 3
        int thirstDecrease = Random.Range(1, 5); // Decrease thirst by random amount between 1 and 3

        currentHunger -= hungerDecrease;
        currentThirst -= thirstDecrease;

        Debug.Log("Hunger: " + currentHunger);
        Debug.Log("Thirst: " + currentThirst);

        UpdateUI();
    }

    void UpdateUI()
    {
        hungerText.text = GetHungerStatus(currentHunger);
        thirstText.text = GetThirstStatus(currentThirst);
    }

    string GetHungerStatus(int value)
    {
        if (value > 7)
        {
            return "Not very hungry";
        }
        else if (value >= 4 && value <= 7)
        {
            return "Kind of hungry";
        }
        else
        {
            return "Very hungry";
        }
    }

    string GetThirstStatus(int value)
    {
        if (value > 7)
        {
            return "Not very thirsty";
        }
        else if (value >= 4 && value <= 7)
        {
            return "Kind of thirsty";
        }
        else
        {
            return "Very thirsty";
        }
    }

    public void IncreaseThirst(int amount)
    {
        currentThirst += amount;
        UpdateUI();
    }

    public void IncreaseHunger(int amount)
    {
        currentHunger += amount;
        UpdateUI();
    }

    public void SetOnMission(bool onMission)
    {
        if (onMission)
        {
            // Set the image to the on mission sprite
            dogImage.sprite = onMissionSprite;
        }
        else
        {
            // Set the image to the normal sprite
            dogImage.sprite = normalSprite;
        }
    }

    public void UpdatePage1Text(string newText)
    {
        page1Text.text = newText;
        page1Text.gameObject.SetActive(true);
    }
}
