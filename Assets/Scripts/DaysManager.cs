using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DaysManager : MonoBehaviour
{
    public int currentDay = 1;
    public int totalDays = 5;
    public TextMeshProUGUI dayText1;
    public TextMeshProUGUI dayText2;
    public GameObject loadingScreen; // Reference to the loading screen Canvas
    public Image fadePanel; // Reference to the black panel for fading
    public GameObject dialogueCanvas;

    public Character human;
    public Character dog;

    private bool waterConsumedToday = false;
    private bool foodConsumedToday = false;

    //Test
    private bool dogOnMission = false;
    private int daysLeftOnMission = 0;


    //Test
    public void SendDogOnMission(ResourceManager resourceManager)
    {
        if (!dogOnMission)
        {
            dogOnMission = true;
            daysLeftOnMission = 2;
            resourceManager.ConsumeResources(0, 0); // Consume no resources initially
        }
        else
        {
            Debug.LogWarning("Dog is already on a mission.");
        }
    }


    public void IncreaseThirst(int amount)
    {
        human.IncreaseThirst(amount);
        dog.IncreaseThirst(amount);
    }

    public void IncreaseHunger(int amount)
    {
        human.IncreaseHunger(amount);
        dog.IncreaseHunger(amount);
    }

    public void NotifyFoodConsumed()
    {
        foodConsumedToday = true;
    }

    public void NotifyWaterConsumed()
    {
        waterConsumedToday = true;
    }

    void Start()
    {
        UpdateDayText();
    }

    public void IncrementDay()
    {
        if (currentDay < totalDays)
        {
            currentDay++;
            Debug.Log("Day " + currentDay);
            UpdateDayText();
        }
        else
        {
            Debug.Log("Game Over");
        }
    }


    public void EndDay(ResourceManager resourceManager)
    {
        //test
        if (dogOnMission)
        {
            daysLeftOnMission--;

            if (daysLeftOnMission == 0)
            {
                dogOnMission = false;

                // Randomly determine whether to bring back food or water
                int randomResource = Random.Range(0, 2);
                if (randomResource == 0)
                {
                    resourceManager.AddResources(0, 1); // Add 1 food
                    Debug.Log("Dog brought back food!");
                }
                else
                {
                    resourceManager.AddResources(1, 0); // Add 1 water
                    Debug.Log("Dog brought back water!");
                }
            }
        }


        if (waterConsumedToday)
        {
            IncreaseThirst(3);
            waterConsumedToday = false; // Reset for the next day
        }

        if (foodConsumedToday)
        {
            IncreaseHunger(3);
            foodConsumedToday = false; // Reset for the next day
        }

        IncrementDay();
        StartCoroutine(ShowLoadingScreen());

        human.DecreaseStats();
        dog.DecreaseStats();

        // Disable dialogue canvas when ending the day
        if (dialogueCanvas != null)
        {
            dialogueCanvas.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Dialogue canvas reference not set in DaysManager script.");
        }
    }
    IEnumerator ShowLoadingScreen()
    {
        // Show the loading screen
        loadingScreen.SetActive(true);
        fadePanel.gameObject.SetActive(true);

        // Display the next day
        dayText1.text = "Day " + currentDay;
        dayText2.text = "Day " + currentDay;

        // Fade in
        float fadeDuration = 1f; // Adjust as needed
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadePanel.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // Wait for a short duration
        yield return new WaitForSeconds(1f); // Adjust as needed

        // Fade out
        timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadePanel.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // Hide the loading screen
        loadingScreen.SetActive(false);
        fadePanel.gameObject.SetActive(false);

        // Load the next day scene (if needed)
        // SceneManager.LoadScene("YourNextDaySceneName");
    }

    void UpdateDayText()
    {
        if (dayText1 != null && dayText2 != null)
        {
            dayText1.text = "Day " + currentDay;
            dayText2.text = "Day " + currentDay;
        }
        else
        {
            Debug.LogWarning("One or both Day Text references not set in DaysManager script.");
        }
    }

}
