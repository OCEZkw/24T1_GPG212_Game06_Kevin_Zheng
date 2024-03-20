using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public int startingHunger = 10;
    public int startingThirst = 10;

    public TextMeshProUGUI hungerText;
    public TextMeshProUGUI thirstText;

    private int currentHunger;
    private int currentThirst;

    void Start()
    {
        currentHunger = startingHunger;
        currentThirst = startingThirst;

        UpdateUI();
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
}