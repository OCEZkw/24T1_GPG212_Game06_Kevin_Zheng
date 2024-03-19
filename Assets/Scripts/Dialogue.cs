using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] List<GameObject> pages;
    int index = 0;
    [SerializeField] GameObject buttonBack;
    [SerializeField] GameObject buttonNext;
    [SerializeField] ResourceManager resourceManager; // Reference to the ResourceManager script

    void Start()
    {
        // Disable back button at the beginning
        buttonBack.SetActive(false);

        // Enable the first page
        ShowPage(index);

        // Update resource UI when dialogue starts
        UpdateResourceUI();
    }

    public void NextPage()
    {
        // Move to the next page if available
        if (index < pages.Count - 1)
        {
            index++;
            ShowPage(index);
        }

        // Update button visibility
        UpdateButtonVisibility();
    }

    public void LastPage()
    {
        // Move to the previous page if available
        if (index > 0)
        {
            index--;
            ShowPage(index);
        }

        // Update button visibility
        UpdateButtonVisibility();
    }

    void ShowPage(int pageIndex)
    {
        // Hide all pages
        foreach (GameObject page in pages)
        {
            page.SetActive(false);
        }

        // Show the specified page
        pages[pageIndex].SetActive(true);
    }

    void UpdateButtonVisibility()
    {
        // Show/hide next button based on current page
        buttonNext.SetActive(index < pages.Count - 1);

        // Show/hide back button based on current page
        buttonBack.SetActive(index > 0);
    }

    // Update UI to reflect current resource counts
    void UpdateResourceUI()
    {
        if (resourceManager != null)
        {
            resourceManager.UpdateResourceUI();
        }
        else
        {
            Debug.LogWarning("Resource Manager reference not set in Dialogue script.");
        }
    }
}
