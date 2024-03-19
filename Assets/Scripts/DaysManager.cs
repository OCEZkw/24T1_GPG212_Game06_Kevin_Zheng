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

    public void EndDay()
    {
        IncrementDay();
        StartCoroutine(ShowLoadingScreen());

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
