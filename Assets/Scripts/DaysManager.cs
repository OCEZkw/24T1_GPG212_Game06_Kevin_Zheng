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
    public DogCharacter dog;

    private bool waterConsumedToday = false;
    private bool foodConsumedToday = false;
  
    private bool dogOnMission = false;
    private int daysLeftOnMission = 0;


    public EventManager eventManager;
    public EventA eventA;
    public EventB eventB;
    public EventC eventC;
    public EventD eventD;
    public TextMeshProUGUI page1Text;
    public ResourceManager resourceManager;
    public DogCharacter dogCharacter;

    public bool playerDeath = false;
    public Image dogMissionImage;


    public void SendDogOnMission(ResourceManager resourceManager)
    {
        if (!dogOnMission)
        {
            dogOnMission = true;
            daysLeftOnMission = 2;
            resourceManager.ConsumeResources(0, 0); // Consume no resources initially
            dog.SetOnMission(true);

            // Disable the UI image when the dog is on a mission
            dogMissionImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Dog is already on a mission.");
        }

    }



    public void IncreaseThirst(int amount)
    {
        if (human != null && dog != null)
        {
            human.IncreaseThirst(amount);
            dog.IncreaseThirst(amount);
        }
        else
        {
            Debug.LogWarning("Human or Dog reference not set in DaysManager script.");
        }
    }

    public void IncreaseHunger(int amount)
    {
        if (human != null && dog != null)
        {
            human.IncreaseHunger(amount);
            dog.IncreaseHunger(amount);
        }
        else
        {
            Debug.LogWarning("Human or Dog reference not set in DaysManager script.");
        }
    }

    public void FeedBoth(int foodAmount, int waterAmount)
    {
        human.IncreaseHunger(foodAmount);
        human.IncreaseThirst(waterAmount);
        dog.IncreaseHunger(foodAmount);
        dog.IncreaseThirst(waterAmount);
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

            if (currentDay % 2 == 0)
            {
                eventManager.TriggerRandomEvent(); // Trigger random event on even days
            }
            if (currentDay == 30)
            {
                eventD.TriggerEvent(); // Trigger EventD when it reaches day 40
            }
        }
        else
        {
            Debug.Log("Game Over");
        }
    }


    public void EndDay(ResourceManager resourceManager)
    {

        if (eventD.evacuateChosen)
        {
            // Player chose to evacuate, go to GameWin scene
            SceneManager.LoadScene("GameWin");
        }
        else if (eventD.stayChosen)
        {
            // Player chose to stay, continue the game
            // Reset the choices for the next day
            eventD.evacuateChosen = false;
            eventD.stayChosen = false;
            eventD.UpdatePage1Text("As the sun rose on another day in the post-apocalyptic wasteland, you find yourself facing another routine day of " +
    "survival. With nosignifcant events to break the monotony, you spent the day manaing your meager resources, ensuring you had enough food and water to last. Despite the lack of excitement, each passing day" +
    "brought you closer to your goal of outlasting the apocalypse and rebuilding society");
        }

        if (eventC.IsPackageOpened())
        {
            // Update the text on page 1 of EventC
            eventC.UpdatePage1Text("As the sun rose on another day in the post-apocalyptic wasteland, you find yourself facing another routine day of " +
                "survival. With nosignifcant events to break the monotony, you spent the day manaing your meager resources, ensuring you had enough food and water to last. Despite the lack of excitement, each passing day" +
                "brought you closer to your goal of outlasting the apocalypse and rebuilding society");
        }
        if (eventC.IsPackageDisposed())
        {
            // Update the text on page 1 of EventC
            eventC.UpdatePage1Text("As the sun rose on another day in the post-apocalyptic wasteland, you find yourself facing another routine day of " +
                "survival. With nosignifcant events to break the monotony, you spent the day manaing your meager resources, ensuring you had enough food and water to last. Despite the lack of excitement, each passing day" +
                "brought you closer to your goal of outlasting the apocalypse and rebuilding society");
        }

        if (eventA.IsEventTriggered())
        {
            // Update the text on page 1 of EventC
            eventA.UpdatePage1Text("As the sun rose on another day in the post-apocalyptic wasteland, you find yourself facing another routine day of " +
                "survival. With nosignifcant events to break the monotony, you spent the day manaing your meager resources, ensuring you had enough food and water to last. Despite the lack of excitement, each passing day" +
                "brought you closer to your goal of outlasting the apocalypse and rebuilding society");
        }



        if (playerDeath)
        {
            // Player has died, go to GameOver scene
            SceneManager.LoadScene("GameOver");
            return; // Exit the method to prevent further processing
        }
        // Reset playerDeath for the next day
        playerDeath = false;

        // Process EventB outcome
        if (eventB.letThemIn)
        {
            // Update the text on page 1
            page1Text.text = "You let them in, but they steal all your food and water.";

            // End the day with the negative outcome
            resourceManager.ConsumeResources(resourceManager.startingWater, resourceManager.startingFood);

            eventB.letThemInButton.gameObject.SetActive(false);
            eventB.dontLetThemInButton.gameObject.SetActive(false);
        }
        else if (eventB.dontLetThemIn)
        {
            // Update the text on page 1
            page1Text.text = "You refuse to let them in. The next day, you find them dead outside.";

            // End the day with the positive outcome
            resourceManager.AddResources(2, 2); // Add 2 water and 2 food

            eventB.letThemInButton.gameObject.SetActive(false);
            eventB.dontLetThemInButton.gameObject.SetActive(false);
        }

        // Reset the choices for the next day
        eventB.letThemIn = false;
        eventB.dontLetThemIn = false;


        if (daysLeftOnMission > 0)
        {
            daysLeftOnMission--;

            if (daysLeftOnMission == 0)
            {
                dogOnMission = false;

                // Enable the UI image when the dog returns from a mission
                dogMissionImage.gameObject.SetActive(true);

                dogCharacter.UpdatePage1Text("Hmmmmm Timmy looks different but I'm not sure where");

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
