using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class ResourceManager : MonoBehaviour
{
    public int waterCount = 5; // Initial amount of water
    public int foodCount = 5; // Initial amount of food
    public GameObject waterPrefab; // Prefab for water bottle image
    public GameObject foodPrefab; // Prefab for food plate image
    private GameObject[] waterBottles; // Array of water bottle GameObjects
    private GameObject[] foodPlates; // Array of food plate GameObjects

    void Start()
    {
        // Instantiate water bottles
        waterBottles = new GameObject[waterCount];
        for (int i = 0; i < waterCount; i++)
        {
            waterBottles[i] = Instantiate(waterPrefab, transform);
        }

        // Instantiate food plates
        foodPlates = new GameObject[foodCount];
        for (int i = 0; i < foodCount; i++)
        {
            foodPlates[i] = Instantiate(foodPrefab, transform);
        }
    }

    // Use water resource
    public void UseWater()
    {
        if (waterCount > 0)
        {
            waterCount--;
            Destroy(waterBottles[waterCount]); // Remove one water bottle from UI
        }
        else
        {
            Debug.Log("Out of water!");
            // You can add additional logic here, like showing a message to the player
        }
    }

    // Use food resource
    public void UseFood()
    {
        if (foodCount > 0)
        {
            foodCount--;
            Destroy(foodPlates[foodCount]); // Remove one food plate from UI
        }
        else
        {
            Debug.Log("Out of food!");
            // You can add additional logic here, like showing a message to the player
        }
    }

    // Update UI to reflect current resource counts
    public void UpdateResourceUI()
    {
        // Update water UI
        for (int i = 0; i < waterBottles.Length; i++)
        {
            if (i < waterCount)
            {
                waterBottles[i].SetActive(true); // Show water bottle image
            }
            else
            {
                waterBottles[i].SetActive(false); // Hide water bottle image
            }
        }

        // Update food UI
        for (int i = 0; i < foodPlates.Length; i++)
        {
            if (i < foodCount)
            {
                foodPlates[i].SetActive(true); // Show food plate image
            }
            else
            {
                foodPlates[i].SetActive(false); // Hide food plate image
            }
        }
    }
}
