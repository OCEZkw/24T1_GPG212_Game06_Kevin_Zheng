using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int startingHunger = 10;
    public int startingThirst = 10;

    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI thirstText;

    private int currentHunger;
    private int currentThirst;

    public Image humanImage;
    public Sprite deadSprite;

    public TextMeshProUGUI page3Text;

    public DaysManager daysManager;

    void Start()
    {
        currentHunger = startingHunger;
        currentThirst = startingThirst;

        page3Text.gameObject.SetActive(false);

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
        humanImage.sprite = deadSprite;

        // Check if the dog is dead
        if (currentHunger <= 0 || currentThirst <= 0)
        {
            // Update the canvas text for page3 if the dog is dead
            page3Text.text = "Oh looks like you have died. I guess you didn't really make the best choices this time. Oh well try better in your next life hahaha";
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

        if (currentHunger <= 0 || currentThirst <= 0)
        {
            daysManager.playerDeath = true; // Declare the player dead
        }

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
}